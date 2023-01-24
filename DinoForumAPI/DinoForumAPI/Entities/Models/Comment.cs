using DinoForumAPI.Entities.DTOs;

namespace DinoForumAPI.Entities.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public UserDto User { get; set; }
    }
}
