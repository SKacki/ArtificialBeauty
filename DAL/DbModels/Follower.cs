using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Follower")]
    public class Follower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("FollowingId")]
        public User Following { get; set; }

    }
}