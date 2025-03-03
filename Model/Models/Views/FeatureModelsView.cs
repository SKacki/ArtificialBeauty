namespace Model.Models.Views
{
    public class FeatureModelsView
    {
        public FeatureModelsView() { }
        public FeatureModelsView(IEnumerable<ImageDTO> images)
        {
            Images = images;
        }

        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
