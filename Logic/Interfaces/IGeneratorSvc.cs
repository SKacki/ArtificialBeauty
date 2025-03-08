using Model.Models;
using Model.Models.Workflows;

namespace Logic.Interfaces
{
    public interface IGeneratorSvc
    {
        //public MetadataDTO RemixImage(int metadataId);
        //public string RequestGeneration(GenerationDataDTO metadata);
        public Dictionary<string, WorkflowNode> GetWorkflow(GenerationDataDTO metadata);
        public Task<byte[]?> AskComfyUI(Dictionary<string, WorkflowNode> workflow);
    }
}
