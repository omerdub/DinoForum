namespace DinoForumAPI.Entities.Requests
{
    public class NewPostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
