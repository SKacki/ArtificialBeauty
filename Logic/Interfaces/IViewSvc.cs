using Model.Models.Views;

namespace Logic.Interfaces
{
    public interface IViewSvc
    {
        public UserViewDTO GetUserView(int userId);
        public ModelViewDTO GetModelView(int modelId);
        public OperationsViewDTO GetOperationView(int userId);
        public GeneratorViewDTO GetGeneratorView(int metadataId);
        FeatureImagesView GetFeatureImagesView();
    }
}
