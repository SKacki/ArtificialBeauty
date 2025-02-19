using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? ModelName { get; set; }
        public string? Description { get; set; }
        //Navigation properties
        public ICollection<Metadata> ModelMetadata { get; set; }
        public ICollection<Metadata> Lora1Metadata { get; set; }
        public ICollection<Metadata> Lora2Metadata { get; set; }
    }
}