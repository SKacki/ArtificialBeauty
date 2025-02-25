namespace Model.Models.Views
{
    public class GeneratorViewDTO
    {
        public GeneratorViewDTO() { }
        public GeneratorViewDTO(MetadataDTO metadata) 
        {
            Metadata = metadata;
        }
        public MetadataDTO Metadata { get; set; }
    }
}
