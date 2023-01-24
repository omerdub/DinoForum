using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;

namespace DinoForumAPI.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> Register(RegisterRequest registerRequest);
        Task<UserDto> GetUserByUserName(string userName);
        Task<UserDto> GetUserByUserId(Guid userId);
        Task<bool> IsUserNameExist(string userName);
        Task<bool> Login(LoginRequest loginRequest);
    }
}
