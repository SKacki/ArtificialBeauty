using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class OperationValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OperationVal {  get; set; }

        //Navigation properties
        public Operation Operation { get; set; }
    }
}
