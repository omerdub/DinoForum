using DinoForumAPI.DAL.Repositories;
using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;
using DinoForumAPI.Entities.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DinoForumAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            _logger.LogInformation("Registering a new user...");
            if (!ModelState.IsValid) // Check if the request's model is valid
            {
                string message = "Model sent in the body is invalid";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            if (await _userRepository.IsUserNameExist(registerRequest.UserName)) // Check if username that should be unique is already taken
            {
                string message = "Username already exists.";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            var user = await _userRepository.Register(registerRequest);
            _logger.LogInformation("Response with the new user");
            return Ok(new RegisterResponse()
            {
                IsRegistered = true,
                User = new UserDto()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                }
            });

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation("Logging in...");
            if (!ModelState.IsValid) // Check if the request's model is valid
            {
                string message = "Model sent in the body is invalid";
                _logger.LogWarning(message);
                return BadRequest(new ErrorResponse(message));
            }

            if (! await _userRepository.Login(loginRequest))
            {
                _logger.LogWarning("Login details are wrong");
                return Unauthorized(new LoginResponse()
                {
                    IsAuthenticated = false
                });
            }

            var user = await _userRepository.GetUserByUserName(loginRequest.UserName);

            _logger.LogInformation("Response with the authenticated user");
            return Ok(new LoginResponse()
            {
                IsAuthenticated = true,
                User = new UserDto()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                }
            });
        }
    }
}
