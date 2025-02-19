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
        public int? FollowerId { get; set; }
        public int? FollowingId { get; set; }
        
        [ForeignKey("FollowerId")]
        public User? UserFollower { get; set; }

        [ForeignKey("FollowingId")]
        public User? UserFollowing { get; set; }

    }
}