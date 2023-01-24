using DinoForumAPI.DAL.Data;
using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;

namespace DinoForumAPI.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IDinoForumDbContext _dbContext;

        public PostRepository(IDinoForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> NewPost(NewPostDto newPost)
        {
            var db = await _dbContext.GetData();

            // Creating a new post and adding it to the database
            var post = new Post()
            {
                PostId = Guid.NewGuid(),
                Title = newPost.Title,
                Content = newPost.Content,
                DateTime = DateTime.Now,
                Comments = new List<Comment>(),
                User = newPost.User,
            };
            db.Posts.Add(post);

            await _dbContext.SaveData(db);
            return post;
        }

        public async Task<Comment> NewComment(NewCommentDto newComment)
        {
            // Creating a new comment and adding it to the database
            var db = await _dbContext.GetData();
            var post = db.Posts.FirstOrDefault(p => p.PostId == newComment.PostId);
            if (post != null)
            {
                var comment = new Comment()
                {
                    CommentId = Guid.NewGuid(),
                    Content = newComment.Content,
                    DateTime = DateTime.Now,
                    User = newComment.User,
                };

                post.Comments.Add(comment);
                await _dbContext.SaveData(db);
                return comment;
            }
            throw new Exception($"Post with postId {newComment.PostId} not found");
        }

        public async Task<List<Post>> GetAllPosts()
        {
            // Return all posts in the database
            var db = await _dbContext.GetData();
            return db.Posts;
        }

        public async Task<Post> GetPostByPostId(Guid postId)
        {
            // Return a specific post by id
            var db = await _dbContext.GetData();
            var post = db.Posts.FirstOrDefault(p => p.PostId == postId);
            if(post != null)
            {
                return post;
            }
            throw new Exception($"Post with postId: {postId} not found.");
        }
    }
}
