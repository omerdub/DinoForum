using DinoForumAPI.Entities.Models;

namespace DinoForumAPI.Entities.Responses
{
    public class NewPostResponse
    {
        public bool IsPostCreated { get; set; }
        public Post Post { get; set; }
    }
}
