using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("OperationsHistory")]
    public class OperationsHistory
    {
        public OperationsHistory() { }
        public OperationsHistory(int userId, int operationId, int amount) 
        {
            UserId = userId;
            OperationId = operationId;   
            Amount = amount;
            OperationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public int Amount { get; set; }
        public Tip? Tip { get; set; }
        public DateTime? OperationDate { get; set; }
    }
}