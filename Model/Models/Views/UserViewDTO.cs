namespace Model.Models.Views
{
    public class UserViewDTO
    {
        public UserViewDTO() { }
        public UserViewDTO(UserDTO user, IEnumerable<ImageDTO> images)
        {
            User = user;
            Images = images;
        }
        public UserDTO User { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
