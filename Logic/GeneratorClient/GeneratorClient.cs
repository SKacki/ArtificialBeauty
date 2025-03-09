using Logic.Configs;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Logic
{
    public class GeneratorClient : IGeneratorClient
    {
        private readonly HttpClient _httpClient;

        public GeneratorClient(HttpClient httpClient, IOptions<GeneratorServerSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            return await HandleResponse<T>(response);
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            return await HandleResponse<T>(response);
        }

        public async Task<T?> PostWorkflowAsync<T>(string endpoint, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            return await HandleFile<T>(response);
        }

        private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return default;
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<T?> HandleFile<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) 
                { var error = await response.Content.ReadAsStringAsync(); throw new HttpRequestException($"Request failed: {response.StatusCode} - {error}"); }

            if (typeof(T) == typeof(byte[])) 
            { 
                var stream = await response.Content.ReadAsStreamAsync(); 
                using (var memoryStream = new MemoryStream()) 
                { 
                    await stream.CopyToAsync(memoryStream); 
                    return (T)(object)memoryStream.ToArray(); 
                } 
            }
           var json = await response.Content.ReadAsStringAsync(); 
           return JsonSerializer.Deserialize<T>(json); } 
        }
}