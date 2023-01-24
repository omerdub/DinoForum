using DinoForumAPI.DAL.Repositories;
using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;
using DinoForumAPI.Entities.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DinoForumAPI.Controllers
{
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostController(ILogger<PostController> logger, IPostRepository postRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> NewPost([FromBody] NewPostRequest newPostRequest)
        {
            _logger.LogInformation("Adding a new post...");
            if (!ModelState.IsValid) // Check if the request's model is valid
            {
                string message = "Model sent in the body is invalid";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            try
            {
                var user = await _userRepository.GetUserByUserId(newPostRequest.UserId);
                var newPost = new NewPostDto()
                {
                    Content = newPostRequest.Content,
                    Title = newPostRequest.Title,
                    User = user
                };
                var post = await _postRepository.NewPost(newPost);

                _logger.LogInformation("Response with the new post");
                return Ok(new NewPostResponse()
                {
                    IsPostCreated = true,
                    Post = post
                });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewComment([FromBody] NewCommentRequest newCommentRequest)
        {
            _logger.LogInformation("Adding a new comment...");
            if (!ModelState.IsValid) // Check if the request's model is valid
            {
                string message = "Model sent in the body is invalid";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            try
            {
                var user = await _userRepository.GetUserByUserId(newCommentRequest.UserId); // Check if user exists
                var newComment = new NewCommentDto()
                {
                    User = user,
                    Content = newCommentRequest.Content,
                    PostId = newCommentRequest.PostId,
                };

                var comment = await _postRepository.NewComment(newComment);
                _logger.LogInformation("Response with the new comment");
                return Ok(new NewCommentResponse()
                {
                    IsCommentAdded = true,
                    Comment = comment
                });
            }

            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllPosts();

            if (posts == null)
            {
                string message = "No posts found";
                _logger.LogWarning(message);
                return NotFound(message);
            }

            _logger.LogInformation("Response with all posts");
            return Ok(new GetAllPostsRequest()
            {
                Posts = posts
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetPostByPostId(Guid postId)
        {
            _logger.LogInformation("Getting a post by postId...");
            if (!ModelState.IsValid) // Check if the request's model is valid
            {
                string message = "Model sent in the body is invalid";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            try
            {
                var post = await _postRepository.GetPostByPostId(postId);
                _logger.LogInformation("Response with post");
                return Ok(new GetPostByPostIdResponse()
                {
                    Post = post,
                });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
