namespace DAL.Interfaces
{
    public interface IOperationRepository : IGenericRepository<OperationsHistory>
    {
        public IEnumerable<OperationsHistory> GetUserOperations(int userId);
        public int GetOperationValue(int operationId);
        public void TipImage(int userId, int imageId, int authorId, int amount);
    }
}
