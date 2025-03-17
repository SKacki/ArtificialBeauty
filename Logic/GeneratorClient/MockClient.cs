using Logic.Configs;
using Logic.Interfaces;
using Microsoft.Extensions.Options;

namespace Logic
{
    public class MockClient : IGeneratorClient
    {
        private readonly string _repoPath;

        public MockClient(IOptions<ImageRepositorySettings> options) => _repoPath = options.Value.Path;
        public Task<T?> GetAsync<T>(string endpoint)
        {
            throw new NotImplementedException();
        }
        public Task<T?> PostAsync<T>(string endpoint, object data)
        {
            throw new NotImplementedException();
        }
        public async Task<T?> PostWorkflowAsync<T>(string endpoint, object data)
        {
            var imagePath = Path.Combine(_repoPath, "16b27c8b-1b8c-4eb7-84cd-5cbb71c57ed9.png");

            if (!File.Exists(imagePath))
                throw new FileNotFoundException($"Mock image file not found at {imagePath}");

            byte[] imageData = await File.ReadAllBytesAsync(imagePath);

            if (typeof(T) == typeof(byte[]))
                return (T)(object)imageData; // Cast byte[] to generic T

            throw new InvalidOperationException("Unsupported return type for PostWorkflowAsync.");
        }
    }
}
