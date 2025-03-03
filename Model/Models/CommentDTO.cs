namespace Model.Models
{
    public class CommentDTO
    {
        public int ImageId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string? CommentText { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
