namespace DinoForumAPI.Entities.DTOs
{
    public class NewPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
    }
}
