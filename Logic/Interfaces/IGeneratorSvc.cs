using Model.Models;
using Model.Models.Workflows;

namespace Logic.Interfaces
{
    public interface IGeneratorSvc
    {
        //public void RequestGeneration(MetadataDTO metadata);
        public MetadataDTO RemixImage(int metadataId);
        public string RequestGeneration(GenerationDataDTO metadata);
        public Dictionary<string, WorkflowNode> RequestGeneration(GenerationDataDTO metadata, int tst);
    }
}
