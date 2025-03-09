using Model.Models;
using Model.Models.Workflows;

namespace Logic.Interfaces
{
    public interface IGeneratorSvc
    {
        public MetadataDTO RemixImage(int metadataId);
        public Dictionary<string, WorkflowNode> GetWorkflow(GenerationDataDTO metadata);
        public Task<byte[]?> AskComfyUI(GenerationDataDTO metadata);
        public Task<int?> HealthCheck();
    }
}
