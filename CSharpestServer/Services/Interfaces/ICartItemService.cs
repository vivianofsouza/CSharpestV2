using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddAsync(Guid itemId, Guid cartId, int quantity); // add cartItem to db
        Task RemoveAsync(Guid id, Guid cartId); // remove cartItem from db (say someone removes something from their cart)
        Task AddRangeAsync(IEnumerable<CartItem> items); // add multiple items to cart
        Task ChangeQuantityAsync(Guid cartId, Guid itemId, int Quantity, bool Add); // change cartItem.quantity
        Task<IEnumerable<CartItem>> GetAllAsync(); // get all the cartItems in db
        Task<CartItem?> GetByIdAsync(Guid id); // get a specific cartItem
        CartItem? GetById(Guid id);
        Task<IEnumerable<CartItem>?> GetByCartAsync(Guid cartId); // should get all the items corresponding to the cartId
        Task ClearCartAsync(Guid cartId);
    }
}