﻿using AutoMapper;
using Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;
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
            => new(_modelSvc.GetById(modelId), _imageSvc.GetModelExamples(modelId), _imageSvc.GetModelImages(modelId));

        public UserViewDTO GetUserView(int userId) 
            => new(_userSvc.GetUserById(userId),_imageSvc.GetUnpublished(userId), _imageSvc.GetUserImages(userId));

        public OperationsViewDTO GetOperationView(int userId)
            => new(_operationSvc.GetUserOperations(userId));

        public GeneratorViewDTO GetGeneratorView(int metadataId) 
            => metadataId>0 ? new GeneratorViewDTO(_generatorSvc.RemixImage(metadataId)) : new GeneratorViewDTO();

        public ImagesView GetFeatureImagesView()
        {
            var images = _imageSvc.GetFeaturedImages();
            return new(images);
        }

        public ImagesView GetImagesView(string? searchTerm)
            => searchTerm.IsNullOrEmpty() ? new(_imageSvc.GetAllImages()) : new(_imageSvc.SearchImages(searchTerm));

        public ModelsView GetFeatureModelsView()
        {
            var examples = _modelSvc.GetModelExamples().Select(x => x.ImageId).ToList();
            var images = _imageSvc.GetFeaturedModels(examples);
            return new(images);
        }
        public ModelsView GetAllModelsView()
        {
            var examples = _modelSvc.GetModelExamples().Select(x => x.ImageId).ToList();
            var images = _imageSvc.GetAllModels(examples);
            return new(images);
        }

        public UserViewDTO UserView(int userId)
            => new(_userSvc.GetUserById(userId), _imageSvc.GetUnpublished(userId), _imageSvc.GetUserImages(userId));

        public ModelsView GetAllModels()
        {
            var examples = _modelSvc.GetModelExamples().Select(x => x.ImageId).ToList();
            var images = _imageSvc.GetAllModels(examples);
            return new(images);
        }
    }
}
