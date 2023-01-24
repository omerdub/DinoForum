using DinoForumAPI.Entities.DTOs;

namespace DinoForumAPI.Entities.Responses
{
    public class RegisterResponse
    {
        public bool IsRegistered { get; set; }
        public UserDto User { get; set; }
    }
}
