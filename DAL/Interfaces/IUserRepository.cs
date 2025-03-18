namespace DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public void FollowUser(Follower follow);
        public IEnumerable<Follower> GetFollowers(int userId);
        public void UpdateProfilePicture(ProfilePicture img);
    }
}
