using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class CartService : ICartService
    {
        private readonly StoreContext _storeContext;

        public CartService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public Task AddAsync(Guid cartId, Guid userId)
        {
            Cart cart = new Cart();
            cart.userId = userId;
            _storeContext.carts.Add(cart);
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.carts.AsEnumerable());
        }

        public Cart? GetById(Guid id)
        {
            return _storeContext.carts.Find(id);
        }

        public Task<Cart?> GetByIdAsync(Guid cartId)
        {
            Cart? cart = _storeContext.carts.Find(cartId);
            return Task.FromResult(cart);
        }

        public Task<IEnumerable<Cart>?> GetByUserAsync(Guid userId)
        {
            var carts = _storeContext.carts.Where(cart => cart.userId == userId).ToList();
            return Task.FromResult<IEnumerable<Cart>?>(carts);//should be only one cart
        }

        public Task RemoveAsync(Guid id)
        {
            var cart = _storeContext?.carts.Find(id);

            if (cart != null)
            {
                _storeContext.carts.Remove(cart);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(cart);
        }
    }
}
