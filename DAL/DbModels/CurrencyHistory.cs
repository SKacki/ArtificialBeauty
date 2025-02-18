using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("CurrencyHistory")]
    public class CurrencyHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public int Amount { get; set; }
    }
}