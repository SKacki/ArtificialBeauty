namespace Model.Models.Views
{
    public class ImagesView
    {
        public ImagesView() { }
        public ImagesView(IEnumerable<ImageDTO> images)
        {
            Images = images;
        }

        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
