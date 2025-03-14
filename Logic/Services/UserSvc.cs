﻿using AutoMapper;
using DAL;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

namespace Logic
{
    public class UserSvc : IUserSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IAuthRepository _authRepo;

        public UserSvc(
            IMapper mapper,
            IUserRepository userRepository,
            IAuthRepository authRepository)
        {
            _userRepo = userRepository;
            _mapper = mapper;
            _authRepo = authRepository;
        }

        public UserDTO GetUserById(int id) 
            => _mapper.Map<User,UserDTO>(_userRepo.GetById(id));

        public UserDTO GetUserByEmail(string email)
            => _mapper.Map<User, UserDTO>(_userRepo.GetWhere(x=>x.Email.ToUpper() == email.ToUpper()).FirstOrDefault());

        public async Task<int> PostUser(NewUserDTO newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.UId = Guid.Parse(newUser.Uid);
            user.UserName = newUser.UserName.Substring(0, newUser.UserName.IndexOf("@"));
            user.JoinedDate = DateTime.Now;
            user.Bio = "Hi, i'm new here 👶";
            _userRepo.Add(user);
            return user.ID;
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepo.Update(user);
        }



    }
}
