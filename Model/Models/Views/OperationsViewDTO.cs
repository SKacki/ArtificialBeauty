namespace Model.Models.Views
{
    public class OperationsViewDTO
    {
        public OperationsViewDTO() { }
        public OperationsViewDTO(IEnumerable<OperationDTO> operations)
        {
            Operations = operations;
            Balance = (operations != null) ? Operations.Sum(x=>x.Amount) : 0; 
        }

        public int Balance { get; set; }
        public IEnumerable<OperationDTO> Operations { get; set; } 
    }
}
