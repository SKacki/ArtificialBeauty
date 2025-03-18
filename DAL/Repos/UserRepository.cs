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
                .Include(x=>x.Picture)
                .Where(x => x.ID == id)
                .SingleOrDefault();
        public override IEnumerable<User> GetWhere(Expression<Func<User, bool>> predicate) =>
            Context.Users
                .Include(x => x.Images)
                .Include(x => x.Followers)
                .Include(x => x.Following)
                .Include(x => x.OperationsHistory)
                .Where(predicate);
        public void FollowUser(Follower follow)
        { 
            Context.Followers.Add(follow);
            Context.SaveChanges();
        }
        public IEnumerable<Follower> GetFollowers(int userId)
            => Context.Followers.Where(x=>x.FollowerId == userId);
        public void UpdateProfilePicture(ProfilePicture img)
        {
            Context.ProfilePictures.RemoveRange(Context.ProfilePictures.Where(x => x.UserId == img.UserId));
            Context.Add(img);
            Context.SaveChanges();
        
        }
    }

}