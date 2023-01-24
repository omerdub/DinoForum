using DinoForumAPI.Entities.DTOs;

namespace DinoForumAPI.Entities.Responses
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public UserDto User { get; set; }
    }
}
