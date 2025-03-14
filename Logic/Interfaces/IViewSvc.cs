﻿using Model.Models.Views;

namespace Logic.Interfaces
{
    public interface IViewSvc
    {
        public UserViewDTO GetUserView(int userId);
        public ModelViewDTO GetModelView(int modelId);
        public OperationsViewDTO GetOperationView(int userId);
        public GeneratorViewDTO GetGeneratorView(int metadataId);
        public ModelsView GetFeatureModelsView();
        public UserViewDTO UserView(int userId);
        public ImagesView GetFeatureImagesView();
        public ImagesView GetImagesView(string? searchTerm);
        public ModelsView GetAllModelsView();
    }
}
