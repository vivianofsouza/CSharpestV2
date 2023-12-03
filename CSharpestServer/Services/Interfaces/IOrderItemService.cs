using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task AddAsync(OrderItem item);
        Task AddRangeAsync(IEnumerable<OrderItem> orderItems);
        Task RemoveAsync(Guid id); // remove OrderItem from db (say someone removes something from their Order)
        Task<IEnumerable<OrderItem>> GetAllAsync(); // get all the OrderItems in db
        Task<OrderItem?> GetByIdAsync(Guid id); // get a specific OrderItem
        OrderItem? GetById(Guid id);
        Task<IEnumerable<OrderItem>?> GetAllByOrderIdAsync(Guid OrderId); // should get all the items corresponding to the OrderId
        IEnumerable<OrderItem>? GetAllByOrderId(Guid OrderId);
    }
}
