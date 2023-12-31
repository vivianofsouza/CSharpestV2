using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> PlaceOrder(Guid userId, Card card, string address); // MAIN Service: calls many other services to place an order    
        public Task<IEnumerable<Order>?> GetOrderHistory(Guid userId); // get user's order history
        public Task RemoveCard(string card_number); // Remove card from account
    }
}