using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public override User GetById(int id) => 
            Context.Users
                .Include(x => x.Images)
                .Include(x => x.Followers)
                .Include(x => x.Following)
                .Include(x => x.OperationsHistory)
                .Where(x => x.ID == id)
                .SingleOrDefault();

        public override IEnumerable<User> GetWhere(Expression<Func<User, bool>> predicate) =>
            Context.Users
                .Include(x => x.Images)
                .Include(x => x.Followers)
                .Include(x => x.Following)
                .Include(x => x.OperationsHistory)
                .Where(predicate);
    }

}