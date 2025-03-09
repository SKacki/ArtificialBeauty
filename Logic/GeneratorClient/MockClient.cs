using Logic.Configs;
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
            var imagePath = Path.Combine(_repoPath, "c530668d-cb80-4807-acf3-3d5e4d727ebf.png");

            if (!File.Exists(imagePath))
                throw new FileNotFoundException($"Mock image file not found at {imagePath}");

            byte[] imageData = await File.ReadAllBytesAsync(imagePath);

            if (typeof(T) == typeof(byte[]))
                return (T)(object)imageData; // Cast byte[] to generic T

            throw new InvalidOperationException("Unsupported return type for PostWorkflowAsync.");
        }
    }
}
