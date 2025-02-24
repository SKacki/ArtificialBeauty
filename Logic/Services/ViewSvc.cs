using AutoMapper;
using Logic.Interfaces;
using Model.Models.Views;

namespace Logic
{
    public class ViewSvc : IViewSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserSvc _userSvc;
        private readonly IImageSvc _imageSvc;
        private readonly IModelSvc _modelSvc;

        public ViewSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IImageSvc imageSvc,
            IModelSvc modelSvc)
        {
            _modelSvc = modelSvc;
            _userSvc = userSvc;
            _imageSvc = imageSvc;
            _mapper = mapper;
        }

        public ModelViewDTO GetModelView(int modelId) 
            => new ModelViewDTO(_modelSvc.GetById(modelId), _imageSvc.GetModelImages(modelId));
    
        public UserViewDTO GetUserView(int userId) 
            => new UserViewDTO(_userSvc.GetUserById(userId),_imageSvc.GetUserImages(userId));
    }
}
