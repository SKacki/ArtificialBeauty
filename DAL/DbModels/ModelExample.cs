using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("ModelExample")]
    public class ModelExample
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageId {  get; set; }
        public int ModelId { get; set; }
        //navigation props
        public Image Image { get; set; }
        public Model Model { get; set; }
    }
}
