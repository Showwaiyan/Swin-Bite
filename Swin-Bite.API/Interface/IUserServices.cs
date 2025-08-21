using SwinBite.Models;

namespace SwinBite.Interface
{
    public interface IUserServices
    {
        public Task<User> Login(string username, string password);

        public Task Logout(int userId);

        public Task<User> UpdateProfile(User userUpdate);
    }
}
