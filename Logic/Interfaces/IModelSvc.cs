using Model.Models;

namespace Logic.Interfaces
{
    public interface IModelSvc
    {
        public IEnumerable<ModelDTO> GetAllModels();
    }
}
