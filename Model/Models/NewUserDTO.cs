namespace Model.Models
{
    public class NewUserDTO
    {
        public string Uid {  get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime? JoinedDate { get; set; }
    }
}
