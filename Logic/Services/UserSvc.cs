using AutoMapper;
using DAL;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;
using model = DAL.Model;

namespace Logic
{
    public class UserSvc : IUserSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public UserSvc(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _userRepo = userRepository;
            _mapper = mapper;
        }

        public UserDTO GetUserById(int id) 
            => _mapper.Map<User,UserDTO>(_userRepo.GetById(id));

    }
}
