namespace Model.Models
{
    public class UserDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public string? Bio { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public int ImagesCount { get; set; }
        public int Currency { get; set; }
        public string? ProfilePic { get; set; }
        public List<string> ShowcaseImages { get; set; }
    }
}
