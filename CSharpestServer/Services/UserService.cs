using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class UserService : IUserService
    {
        private readonly StoreContext _storeContext;

        public UserService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private User GetInitialisedId(User user)
        {
            if (user.Id == Guid.Empty) { user.Id = Guid.NewGuid(); }

            return user;
        }
        public Task AddAsync(User user)
        {
            user = GetInitialisedId(user);
            user.CartId = Guid.NewGuid();
            _storeContext.users.Add(user);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.users.AsEnumerable());
        }

        public User? GetById(Guid id)
        {
            return _storeContext.users.Find(id);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_storeContext.users.Find(id));
        }

        public Task RemoveAsync(Guid id)
        {
            var user = _storeContext?.users.Find(id);

            if (user != null)
            {
                _storeContext.users.Remove(user);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(user);
        }
    }
}
