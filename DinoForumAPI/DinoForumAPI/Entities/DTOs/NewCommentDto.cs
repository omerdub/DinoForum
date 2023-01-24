namespace DinoForumAPI.Entities.DTOs
{
    public class NewCommentDto
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
    }
}
