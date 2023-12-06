using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddToCart(Guid itemId, Guid cartId, int quantity); // add cartItem to db
        Task RemoveFromCart(Guid id, Guid cartId); // remove cartItem from db (say someone removes something from their cart)
        Task ChangeQuantity(Guid cartId, Guid itemId, int Quantity, bool Add); // change cartItem.quantity
        Task<IEnumerable<CartItem>?> GetByCartAsync(Guid cartId); // should get all the items corresponding to the cartId
        Task ClearCart(Guid cartId); // Clear the cart of all items
    }
}