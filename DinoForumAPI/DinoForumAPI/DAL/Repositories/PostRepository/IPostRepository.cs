using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;

namespace DinoForumAPI.DAL.Repositories
{
    public interface IPostRepository
    {
        Task<Post> NewPost(NewPostDto newPostRequest);
        Task<Comment> NewComment(NewCommentDto newComment);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostByPostId(Guid postId);
    }
}
