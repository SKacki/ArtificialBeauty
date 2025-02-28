using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Comment")]
    public class Comment
    {
        public Comment() { }
        public Comment(int imageId, int userId, string comment) 
        {
            ImageId = imageId;
            UserId = userId;
            CommentText = comment;
            CreatedDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int? UserId { get; set; }
        public string? CommentText { get; set; }
        public DateTime? CreatedDate { get; set; }

        //Navigation properties
        public User? User { get; set; }
        public Image Image { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}