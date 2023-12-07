using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CSharpestServer.Services
{
    public class UsersService : IUsersService
    {
        private readonly StoreContext _storeContext;

        public UsersService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        
        public Task AddAsync(User user)
        {
            try
            {
                user = GetInitialisedId(user);
                user.CartId = Guid.NewGuid();
                _storeContext.users.Add(user);
                _storeContext.SaveChanges();
                
                if (!user.IsAdmin)
                {
                    Cart cart = new Cart(user);
                    _storeContext.carts.Add(cart);
                    _storeContext.SaveChanges();
                }

            } catch
            {
                throw;
            }

            return Task.CompletedTask;
        }

        public Task<User> Login(string email, string password)
        {
            var users = _storeContext.users.AsEnumerable();
            try
            {
                var found = users
                            .Select(user =>  user)
                            .Where(user => user.Email == email);
                var user = found.FirstOrDefault();

                if (user != null && user.Password == password)
                {
                    return Task.FromResult(user);
                } else
                {
                    //wrong password
                    return Task.FromException<User>(new InvalidOperationException($"Login/password is incorrect"));
                }
            } catch
            {
                throw;
            }
        }

        public Task DeleteUser(Guid id)
        {
            try
            {
                var user = _storeContext.users.Find(id);
                _storeContext.users.Remove(user);
                _storeContext.SaveChanges();

            } catch
            {
                throw;
            }       

            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return Task.FromResult(_storeContext.users.AsEnumerable());
            } catch
            {
                throw;
            }
                
        }

        //PROFILE MODIFICATION
        public Task ChangeFName(Guid userId, string newName)
        {
            try
            {
                User? _user = _storeContext.users.Find(userId);
                if (_user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found.");
                }

                _user.FirstName = newName;
                _storeContext.SaveChanges();
                return Task.CompletedTask;
            }   catch
            {
                throw;
            }
        }
        public Task ChangeLName(Guid userId, string newName)
        {
            try
            {
                User? _user = _storeContext.users.Find(userId);
                if (_user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found.");
                }

                _user.LastName = newName;
                _storeContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
        public Task ChangeEmail(Guid userId, string email)
        {
            try
            {
                User? _user = _storeContext.users.Find(userId);
                if (_user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found.");
                }

                _user.Email = email;
                _storeContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }

        public Task ChangePW(Guid userId, string password)
        {
            try
            {
                User? _user = _storeContext.users.Find(userId);
                if (_user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found.");
                }

                _user.Password = password;
                _storeContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }

        //PRIVATE SERVICES
        private User GetInitialisedId(User user)
        {
            if (user.Id == Guid.Empty) { user.Id = Guid.NewGuid(); }

            return user;
        }
    }
}
