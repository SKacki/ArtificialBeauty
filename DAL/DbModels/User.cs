using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? UserName {  get; set; }
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public string? Bio { get; set; }
        //Navigation properties
        public ProfilePicture Picture { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Follower> Following { get; set; }
        public ICollection<OperationsHistory> OperationsHistory { get; set; }
    }
}