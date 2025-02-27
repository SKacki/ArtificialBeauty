namespace Model.Models.Views
{
    public class FeatureImagesView
    {
        public FeatureImagesView() { }
        public FeatureImagesView(IEnumerable<ImageDTO> images)
        {
            Images = images;
        }

        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
