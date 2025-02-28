using Model.Models;

namespace Logic.Interfaces
{
    public interface IGeneratorSvc
    {
        public void RequestGeneration(MetadataDTO metadata);
        public MetadataDTO RemixImage(int metadataId);
    }
}
