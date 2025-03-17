using Logic.Configs;
using Microsoft.Extensions.Options;
using Model.Models.Workflows;
using System.Net.Http;

namespace Logic.WebSocket
{
    public class MockSocket : IWebSocketSvc
    {
        private readonly string _repoPath;

        public MockSocket(IOptions<ImageRepositorySettings> options) => _repoPath = options.Value.Path;

        public async Task<byte[]> FetchImageFromComfyAsync(Dictionary<string, WorkflowNode> workflow, string uid)
        {
            var imagePath = Path.Combine(_repoPath, "16b27c8b-1b8c-4eb7-84cd-5cbb71c57ed9.png");

            if (!File.Exists(imagePath))
                throw new FileNotFoundException($"Mock image file not found at {imagePath}");

            byte[] imageData = await File.ReadAllBytesAsync(imagePath);
            return imageData;
        }
    }
}
