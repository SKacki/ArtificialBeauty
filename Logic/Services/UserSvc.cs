using AutoMapper;
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
        private readonly IImageSvc _imageSvc;

        public UserSvc(
            IMapper mapper,
            IUserRepository userRepository,
            IAuthRepository authRepository,
            IImageSvc imageSvc)
        {
            _userRepo = userRepository;
            _mapper = mapper;
            _authRepo = authRepository;
            _imageSvc = imageSvc;
        }

        public UserDTO GetUserById(int id) 
            => _mapper.Map<User,UserDTO>(_userRepo.GetById(id));

        UserDTO IUserSvc.GetUserByUid(Guid uid)
            => _mapper.Map<User, UserDTO>(_userRepo.GetWhere(x=>x.UId == uid).FirstOrDefault());

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

        public async Task FollowUser(FollowDTO followDto)
        {
            if (followDto.FollowerId == null || followDto.FollowingId == null)
                throw new Exception("Something went wrong :(");

            if (!_userRepo.GetFollowers(followDto.FollowerId ?? -1).Any(x => x.FollowingId == (int)followDto.FollowingId))
            {
                var follow = _mapper.Map<Follower>(followDto);
                _userRepo.FollowUser(follow);
            }

        }

        public async Task UpdateProfilePic(byte[] profilePic, int userId)
        { 
            var fileName = _imageSvc.SaveProfilePic(profilePic);
            ProfilePicture pic = new() 
            { 
               UserId = userId,
               Ref = fileName
            };

            _userRepo.UpdateProfilePicture(pic);
        }
    }
}
