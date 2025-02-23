using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Images")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Ref { get; set; }
        public string? Description { get; set; }
        public int MetadataId { get; set; }
        public int UserId { get; set; }
        public DateTime? UploadDate { get; set; }
        //Navigation properties
        public Metadata Metadata { get; set; }
        public User User { get; set; }
        public ICollection<Tip> Tips {  get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<ImagesCollection> Collections { get; set; }   

    }
}