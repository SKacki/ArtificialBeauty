namespace Model.Models.Views
{
    public class ModelViewDTO
    {
        public ModelViewDTO() { }
        public ModelViewDTO(ModelDTO model, IEnumerable<ImageDTO> examples, IEnumerable<ImageDTO> images) 
        { 
            Images = images;
            Model = model;
            Examples = examples;
        }

        public ModelDTO Model { get; set; }
        public IEnumerable<ImageDTO> Examples { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
