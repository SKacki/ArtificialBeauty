namespace Model.Models.Views
{
    public class ModelsView
    {
        public ModelsView() { }
        public ModelsView(IEnumerable<ImageDTO> images)
        {
            Images = images;
        }

        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
