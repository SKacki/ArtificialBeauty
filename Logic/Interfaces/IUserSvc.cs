using Model.Models;

namespace Logic.Interfaces
{
    public interface IUserSvc
    {
        public UserDTO GetUserById(int id);
        public UserDTO GetUserByEmail(string email);
        public UserDTO GetUserByUid(Guid uid);
        public Task<int> PostUser(NewUserDTO newUser);
        public Task UpdateUser(UserDTO userDto);
        public Task FollowUser(FollowDTO followerDto);
        public Task UpdateProfilePic(byte[] profilePic, int userId);
    }
}
