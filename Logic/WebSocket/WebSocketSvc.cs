using Logic.Configs;
using Microsoft.Extensions.Options;
using Model.Models.Workflows;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;


namespace Logic
{ 
    public class WebSocketSvc : IWebSocketSvc
    {
        private readonly string _serverAddress;
        private readonly HttpClient _httpClient;
        private string _clientId;

        public WebSocketSvc(HttpClient httpClient, IOptions<GeneratorServerSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"http://{options.Value.BaseUrl}");
            _serverAddress = options.Value.BaseUrl;
        }
        public async Task<byte[]> FetchImageFromComfyAsync(Dictionary<string, WorkflowNode> workflow, string uid)
        {
            SetClientId(uid);
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri($"ws://{_serverAddress}/ws?clientId={_clientId}"), CancellationToken.None);

            string workflowJson = JsonSerializer.Serialize(workflow);
            using JsonDocument doc = JsonDocument.Parse(workflowJson);

            byte[] images = await GetImagesAsync(ws, doc.RootElement);

            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
            return images;
        }
        private async Task<string> QueuePromptAsync(string workflowJson)
        {
            var payload = new
            {
                prompt = JsonDocument.Parse(workflowJson).RootElement,
                client_id = _clientId
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"http://{_serverAddress}/prompt", content);
            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseString);
            return doc.RootElement.GetProperty("prompt_id").GetString();
        }
        private async Task<byte[]> GetImagesAsync(ClientWebSocket ws, JsonElement prompt)
        {
            string promptId = await QueuePromptAsync(prompt.ToString());
            byte[] outputImage = null;
            string currentNode = "";

            var buffer = new byte[4096];

            while (ws.State == WebSocketState.Open)
            {
                var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    using JsonDocument doc = JsonDocument.Parse(message);
                    var messageType = doc.RootElement.GetProperty("type").GetString();

                    if (messageType == "executing")
                    {
                        var data = doc.RootElement.GetProperty("data");
                        if (data.GetProperty("prompt_id").GetString() == promptId)
                        {
                            if (data.GetProperty("node").ValueKind == JsonValueKind.Null)
                                break;
                            else
                            {
                                int nodeNumber = data.GetProperty("node").GetInt32();
                                currentNode = prompt.EnumerateArray().ElementAt(nodeNumber).GetProperty("class_type").GetString();
                            }
                        }
                    }
                }
                else if (currentNode == "SaveImageWebsocket")
                {
                    outputImage = buffer.Skip(8).ToArray();
                }
            }

            return outputImage;
        }
        private void SetClientId(string uid) => _clientId = uid;

    }
}
