using DinoForumAPI.DAL.Data;
using DinoForumAPI.Entities.DTOs;
using DinoForumAPI.Entities.Models;
using DinoForumAPI.Entities.Requests;
using DinoForumAPI.Services.PasswordHelper;

namespace DinoForumAPI.DAL.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly IDinoForumDbContext _dbContext;
        private readonly IPasswordHelper _passwordHelper;

        public UsersRepository(IDinoForumDbContext userContext, IPasswordHelper passwordHelper)
        {
            _dbContext = userContext;
            _passwordHelper = passwordHelper;
        }

        public async Task<UserDto> Register(RegisterRequest registerRequest)
        {
            // Hashing password
            byte[] salt = _passwordHelper.GenerateSalt();
            string hashedPassword = _passwordHelper.HashPassword(registerRequest.Password, salt);

            // Creating a new user and saving in DB
            var newUser = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = registerRequest.UserName,
                Salt = _passwordHelper.GetSaltString(salt),
                HashedPassword = hashedPassword,
            };

            var updatedDb = await _dbContext.GetData();
            updatedDb.Users.Add(newUser);
            await _dbContext.SaveData(updatedDb);

            return new UserDto()
            {
                UserName = newUser.UserName,
                UserId = newUser.UserId
            };
        }

        public async Task<UserDto> GetUserByUserName(string userName)
        {
            // Get user from database by user name
            var db = await _dbContext.GetData();
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);
            if(user != null)
            {
                return new UserDto()
                {
                    UserName = user.UserName,
                    UserId = user.UserId
                };
            }

            throw new Exception($"User with userName {userName} not found");
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            // Get user from database by user id
            var db = await _dbContext.GetData();
            return db.Users.Any(u => u.UserName ==userName);
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            // Get user by user name
            var db = await _dbContext.GetData();
            var user = db.Users.FirstOrDefault(u => u.UserName == loginRequest.UserName);
            if (user == null)
            {
                return false;
            }

            // Verify between the given password and the hashed user's password in the database
            return _passwordHelper.VerifyPassword(loginRequest.Password, _passwordHelper.GetSaltByteArray(user.Salt), user.HashedPassword);
        }

        public async Task<UserDto> GetUserByUserId(Guid userId)
        {
            //Get user by user id
            var db = await _dbContext.GetData();
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                return new UserDto()
                {
                    UserName = user.UserName,
                    UserId = userId
                };
            }

            throw new Exception($"User with userId {userId} not found");
        }
    }
}
