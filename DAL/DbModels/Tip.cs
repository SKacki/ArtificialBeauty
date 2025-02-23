using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Tip")]
    public class Tip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageId {  get; set; }
        public int OperationId { get; set; }
        [ForeignKey("OperationId")]
        public OperationsHistory Operation { get; set; }
        public Image Image { get; set; }
    }
}