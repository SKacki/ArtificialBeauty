namespace Logic.Interfaces
{
    public interface IGeneratorClient
    {
        public Task<T?> GetAsync<T>(string endpoint);
        public Task<T?> PostAsync<T>(string endpoint, object data);
        public Task<T?> PostWorkflowAsync<T>(string endpoint, object data);
    }
}