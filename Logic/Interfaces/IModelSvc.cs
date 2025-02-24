using Model.Models;

namespace Logic.Interfaces
{
    public interface IModelSvc
    {
        public IEnumerable<ModelDTO> GetAll();
        public IEnumerable<ModelDTO> SearchByName(string searchTerm);
        public IEnumerable<ModelDTO> GetCheckpoints();
        public IEnumerable<ModelDTO> GetAdditionalResources();
        public ModelDTO GetById(int modelId);
    }
}
