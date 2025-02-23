using Model.Models;

namespace Logic.Interfaces
{
    public interface IViewSvc
    {
        public IEnumerable<ModelDTO> GetUserView(int userId);
    }
}
