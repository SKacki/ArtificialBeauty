using Model.Models.Workflows;

namespace Logic
{
    public interface IWebSocketSvc
    {
        public Task<byte[]> FetchImageFromComfyAsync(Dictionary<string, WorkflowNode> workflow, string uid);
    }
}
