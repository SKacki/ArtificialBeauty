using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Reaction")]
    public class Reaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Type {  get; set; }
        public int? ImageId { get; set; }
        public int? CommentId { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public Image? Image { get; set; }
        public Comment? Comment { get; set; }
    }
}