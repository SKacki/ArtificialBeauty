namespace Model.Models
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public Guid Ref { get; set; }
        public string? Description { get; set; }
        public int MetadataId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? UploadDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Tips { get; set; }
        public int CommentsCount { get; set; }
        public int? ExampleOfModel { get; set; }
    }
}
