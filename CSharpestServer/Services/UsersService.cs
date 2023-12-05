using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class UsersService : IUsersService
    {
        private readonly StoreContext _storeContext;

        public UsersService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


    }
}
