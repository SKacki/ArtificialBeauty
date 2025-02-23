using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

namespace Logic
{
    public class ViewSvc : IViewSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserSvc _userSvc;

        public ViewSvc(
            IMapper mapper,
            IGeneratorSvc generatorSvc,
            IUserSvc userSvc,
            IModelRepository modelRepository)
        {
            _userSvc = userSvc;
            _mapper = mapper;
        }

        public IEnumerable<ModelDTO> GetUserView(int userId)
        {
            //var result = _userSvc.
            throw new NotImplementedException();
        }
    }
}
