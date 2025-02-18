using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("ImagesCollection")]
    public class ImagesCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CollectionId {  get; set; }
        public int ImageId {  get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Collection> Collections { get; set; }
    }
}