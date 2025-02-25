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
        private readonly IOperationSvc _operationSvc;
        private readonly IGeneratorSvc _generatorSvc;

        public ViewSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IImageSvc imageSvc,
            IModelSvc modelSvc,
            IOperationSvc operationSvc,
            IGeneratorSvc generatorSvc)
        {
            _modelSvc = modelSvc;
            _userSvc = userSvc;
            _imageSvc = imageSvc;
            _mapper = mapper;
            _operationSvc = operationSvc;
            _generatorSvc = generatorSvc;
        }

        public ModelViewDTO GetModelView(int modelId) 
            => new ModelViewDTO(_modelSvc.GetById(modelId), _imageSvc.GetModelImages(modelId));
    
        public UserViewDTO GetUserView(int userId) 
            => new UserViewDTO(_userSvc.GetUserById(userId),_imageSvc.GetUserImages(userId));
        public OperationsViewDTO GetOperationView(int userId)
            => new OperationsViewDTO(_operationSvc.GetUserOperations(userId));

        public GeneratorViewDTO GetGeneratorView(int metadataId) 
            => metadataId>0 ? new GeneratorViewDTO(_generatorSvc.RemixImage(metadataId)) : new GeneratorViewDTO();
        
    }
}
