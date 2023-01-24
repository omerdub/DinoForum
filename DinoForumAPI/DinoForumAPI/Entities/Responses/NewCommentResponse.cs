using DinoForumAPI.Entities.Models;

namespace DinoForumAPI.Entities.Responses
{
    public class NewCommentResponse
    {
        public bool IsCommentAdded { get; set; }
        public Comment Comment { get; set; }
    }
}
