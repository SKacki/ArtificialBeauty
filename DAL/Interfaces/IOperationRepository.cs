namespace DAL.Interfaces
{
    public interface IOperationRepository : IGenericRepository<OperationsHistory>
    {
        public IEnumerable<OperationsHistory> GetUserOperations(int userId);
    }
}
