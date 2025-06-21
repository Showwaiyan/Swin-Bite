using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class UserService
    {
        private readonly UserRespository _repo;

        public UserService(UserRespository repo)
        {
            _repo = repo;
        }

        public async Task<User> Login(string username, string password)
        {
            User user = await _repo.GetByNameAsync(username);
            if (user == null)
                throw new ArgumentException("Invalid information");

            if (!user.Login(password))
                throw new UnauthorizedAccessException("Your have provided invalid information");

            return user;
        }

        public async Task Logout(int userId)
        {
            User user = await _repo.GetByIdAsync(userId);
            if (user == null)
                throw new ArgumentException("Invalid information");
            user.Logout();
        }
    }
}
