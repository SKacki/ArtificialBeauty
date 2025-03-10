namespace Model.Models.Views
{
    public class UserViewDTO
    {
        public UserViewDTO() { }
        public UserViewDTO(UserDTO user, IEnumerable<ImageDTO> unpublished, IEnumerable<ImageDTO> images)
        {
            User = user;
            UnpublishedImages = unpublished;
            Images = images;
        }
        public UserDTO User { get; set; }
        public IEnumerable<ImageDTO> UnpublishedImages { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
