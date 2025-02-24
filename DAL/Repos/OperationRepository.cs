using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repos
{
    public class OperationRepository : GenericRepository<OperationsHistory>, IOperationRepository
    {
        public OperationRepository(AppDbContext context) : base(context) { }

        public override IQueryable<OperationsHistory> GetAllAsIQueryable()
            => Context.OperationsHistory.Include(oh => oh.Operation);

        public IEnumerable<OperationsHistory> GetUserOperations(int userId)
            => GetAllAsIQueryable().Where(x=>x.UserId == userId);
    }
}