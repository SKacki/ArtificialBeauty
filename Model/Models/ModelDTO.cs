namespace Model.Models
{
    public class ModelDTO
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? ModelName { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Trigger { get; set; }
        public string? Description { get; set; }
        public int? PublisherId { get; set; }
    }
}