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
        private readonly IModelRepository _modelRepo;
        private readonly IUserSvc _userSvc;
        private readonly IGeneratorSvc _generatorSvc;

        public UserSvc(
            IMapper mapper,
            IGeneratorSvc generatorSvc,
            IUserSvc userSvc,
            IModelRepository modelRepository)
        {
            _userSvc = userSvc;
            _generatorSvc = generatorSvc;
            _modelRepo = modelRepository;
            _mapper = mapper;
        }

    }
}
