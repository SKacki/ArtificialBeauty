using Model.Models;

namespace Logic.Interfaces
{
    public interface IUserSvc
    {
        public UserDTO GetUserById(int id);
    }
}
