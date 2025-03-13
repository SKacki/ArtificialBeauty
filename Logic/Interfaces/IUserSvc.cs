using Model.Models;

namespace Logic.Interfaces
{
    public interface IUserSvc
    {
        public UserDTO GetUserById(int id);
        public Task<int> PostUser(NewUserDTO newUser);
        public UserDTO GetUserByEmail(string email);
        public Task UpdateUser(UserDTO userDto);
    }
}
