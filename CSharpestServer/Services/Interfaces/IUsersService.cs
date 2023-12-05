using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User> Login(string email, string password); //Login user
        public Task AddAsync(User user); // Creates user
        public Task DeleteUser(Guid id); // Delete user
        Task<IEnumerable<User>> GetAllAsync(); // see all users in db
    }
}
