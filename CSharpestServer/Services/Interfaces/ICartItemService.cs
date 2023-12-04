using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddAsync(CartItem item); // add cartItem to db
        Task RemoveAsync(Guid id); // remove cartItem from db (say someone removes something from their cart)
        Task AddRangeAsync(IEnumerable<CartItem> items); // add multiple items to cart
        Task ChangeQuantityAsync(Guid cartItemId, int Quantity, string AddOrRemove); // change cartItem.quantity
        Task<IEnumerable<CartItem>> GetAllAsync(); // get all the cartItems in db
        Task<CartItem?> GetByIdAsync(Guid id); // get a specific cartItem
        CartItem? GetById(Guid id);
        Task<IEnumerable<CartItem>?> GetByCartAsync(Guid cartId); // should get all the items corresponding to the cartId
        
    }
}