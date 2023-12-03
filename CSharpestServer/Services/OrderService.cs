using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreContext _storeContext;

        public OrderService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private Order GetInitialisedId(Order order)
        {
            if (order.Id == Guid.Empty) { order.Id = Guid.NewGuid(); }

            return order;
        }
        public Task AddAsync(Order order)
        {
            order = GetInitialisedId(order);
            _storeContext.orders.Add(order);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Order? GetById(Guid id)
        {
            return _storeContext.orders.Find(id);
        }

        public Task<Order?> GetByIdAsync(Guid orderId)
        {
            return Task.FromResult(_storeContext.orders.Find(orderId));
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.orders.AsEnumerable());
        }

        public Task<IEnumerable<Order>?> GetByUserIdAsync(Guid userId)
        {
            var orders = _storeContext.orders.Where(order => order.UserId == userId).ToList();
            return Task.FromResult<IEnumerable<Order>?>(orders);
        }

        public IEnumerable<Order?> GetByUserId(Guid userId)
        { // all the orders the user has made
            var orders = _storeContext.orders.Where(order => order.UserId == userId).ToList();
            return orders;
        }

        public Task RemoveAsync(Guid id)
        {
            var order = _storeContext?.orders.Find(id);

            if (order != null)
            {
                _storeContext.orders.Remove(order);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(order);
        }
    }
}
