using Model.Models;

namespace Logic.Interfaces
{
    public interface IOperationSvc
    {
        public IEnumerable<OperationDTO> GetUserOperations(int userId);
    }
}
