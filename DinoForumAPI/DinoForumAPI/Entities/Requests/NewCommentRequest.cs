namespace DinoForumAPI.Entities.Requests
{
    public class NewCommentRequest
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
