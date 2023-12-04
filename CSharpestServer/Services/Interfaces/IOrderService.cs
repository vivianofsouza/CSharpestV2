using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddAsync(Order order);
        Task RemoveAsync(Guid id);
        public Order? GetById(Guid id);
        public Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>?> GetByUserIdAsync(Guid userId); // should get all the items corresponding to a user
        IEnumerable<Order?> GetByUserId(Guid userId);
    }
}