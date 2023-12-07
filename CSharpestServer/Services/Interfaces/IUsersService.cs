using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User> Login(string email, string password); //Login user
        public Task ChangeFName(Guid userId, string newName); //Change user's first name
        public Task ChangeLName(Guid userId, string newName); //Change user's last name
        public Task ChangeEmail(Guid userId, string email); //Change user's email
        public Task ChangePW(Guid userId, string password); //Change user's password
        public Task AddAsync(User user); // Creates user
        public Task DeleteUser(Guid id); // Delete user
        Task<IEnumerable<User>> GetAllAsync(); // see all users in db
    }
}
