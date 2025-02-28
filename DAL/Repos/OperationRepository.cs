using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DAL.Repos
{
    public class OperationRepository : GenericRepository<OperationsHistory>, IOperationRepository
    {
        public OperationRepository(AppDbContext context) : base(context) { }

        public override IQueryable<OperationsHistory> GetAllAsIQueryable()
            => Context.OperationsHistory.Include(oh => oh.Operation).ThenInclude(o=>o.Value);

        public IEnumerable<OperationsHistory> GetUserOperations(int userId)
            => GetAllAsIQueryable().Where(x=>x.UserId == userId);
        public int GetOperationValue(int operationId) 
            => Context.OperationValues.SingleOrDefault(x=>x.OperationId == operationId).OperationVal;

        public override IEnumerable<OperationsHistory> GetWhere(Expression<Func<OperationsHistory, bool>> predicate)
            => GetAllAsIQueryable().Where(predicate);

        public void TipImage(int userId, int imageId, int authorId, int amount)
        {
            var operation1 = new OperationsHistory(userId, 7, -amount);//deduct from the user
            var operation2 = new OperationsHistory(authorId, 1, amount);//add to the author
            base.Add(operation1);
            base.Add(operation2);
            Context.Tips.Add(new(imageId, operation2.Id));
            base.SaveChanges();
        }

    }
}