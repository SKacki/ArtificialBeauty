namespace Model.Models
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime? OperationDate { get; set; }
    }
}
