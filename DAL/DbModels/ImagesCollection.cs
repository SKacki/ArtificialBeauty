using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("ImagesCollection")]
    public class ImagesCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CollectionId {  get; set; }
        public int ImageId {  get; set; }

        [ForeignKey("ImageId")]
        public Image Image { get; set; }
        [ForeignKey("CollectionId")]
        public Collection Collection { get; set; }
    }
}