using DinoForumAPI.Entities.DTOs;

namespace DinoForumAPI.Entities.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public UserDto User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
