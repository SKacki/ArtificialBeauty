namespace Model.Models.Views
{
    public class ModelViewDTO
    {
        public ModelViewDTO() { }
        public ModelViewDTO(ModelDTO model,IEnumerable<ImageDTO> images) 
        { 
            Images = images;
            Model = model;
        }

        public ModelDTO Model { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
