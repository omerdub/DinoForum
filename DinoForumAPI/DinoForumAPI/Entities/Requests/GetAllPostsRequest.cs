using DinoForumAPI.Entities.Models;

namespace DinoForumAPI.Entities.Requests
{
    public class GetAllPostsRequest
    {
        public List<Post> Posts { get; set; }
    }
}
