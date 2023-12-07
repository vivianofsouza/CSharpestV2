using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly StoreContext _storeContext;

        public OrderItemService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private OrderItem GetInitialisedId(OrderItem item)
        {
            if (item.Id == Guid.Empty) { item.Id = Guid.NewGuid(); }

            return item;
        }
        public Task AddAsync(OrderItem item)
        {
            try
            {
                item = GetInitialisedId(item);
                _storeContext.orderItems.Add(item);
                _storeContext.SaveChanges();

                return Task.CompletedTask;
            } catch
            {
                throw;
            }
            
        }
        public Task AddRangeAsync(IEnumerable<OrderItem> items)
        {
            foreach (var i in items)
            {
                _storeContext.Add(GetInitialisedId(i));
            }
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.orderItems.AsEnumerable());
        }

        public IEnumerable<OrderItem>? GetAllByOrderId(Guid OrderId)
        {
            var orders = _storeContext.orderItems.Where(item => item.OrderId == OrderId).ToList();
            return orders;
        }

        public Task<IEnumerable<OrderItem>?> GetAllByOrderIdAsync(Guid OrderId)
        {
            var items = _storeContext.orderItems.Where(item => item.OrderId == OrderId).ToList();
            return Task.FromResult<IEnumerable<OrderItem>?>(items);
        }

        public OrderItem? GetById(Guid id)
        {
            return _storeContext.orderItems.Find(id);
        }

        public Task<OrderItem?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_storeContext.orderItems.Find(id));
        }

        public Task RemoveAsync(Guid id)
        {
            var item = _storeContext.orderItems.Find(id);

            if (item != null)
            {
                _storeContext.orderItems.Remove(item);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(item);
        }
    }
}
