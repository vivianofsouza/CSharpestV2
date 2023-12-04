using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;

namespace CSharpestServer.Services
{
    public class ItemService : IItemService
    {
        private readonly StoreContext _storeContext;

        public ItemService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private Item GetInitialisedId(Item item)
        {
            if (item.Id == Guid.Empty) { item.Id = Guid.NewGuid(); }

            return item;
        }

        public Task AddAsync(Item item)
        {
            item = GetInitialisedId(item);
            _storeContext.items.Add(item);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<Item> items)
        {
            foreach (var i in items)
            {
                Item item = GetInitialisedId(i);
                _storeContext.items.Add(item);
            }
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ChangeStockAsync(Guid itemId, int Quantity, string AddOrRemove)
        {
            Item? _item = _storeContext.items.Find(itemId);
            if (_item == null)
            {
                throw new InvalidOperationException($"Item with ID {itemId} not found.");
            }

            if (AddOrRemove == "add")//AddOrRemove.Equals("add", StringComparison.OrdinalIgnoreCase))
            {
                _item.Stock += Quantity;
            }

            if (AddOrRemove == "remove")//AddOrRemove.Equals("remove", StringComparison.OrdinalIgnoreCase))
            {
                if (Quantity > _item.Stock) { _item.Stock = 0; }
                
                else { _item.Stock -= Quantity; }
            }
            _storeContext.SaveChanges();
            return Task.FromResult(_item);
        }

        public Task<IEnumerable<Item>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.items.AsEnumerable());
        }

        public Item? GetById(Guid id)
        {
            return _storeContext.items.Find(id);
        }

        public Task<Item?> GetByIdAsync(Guid id)
        {
            Item? item = _storeContext.items.Find(id);
            return Task.FromResult(item);
        }

        public Task RemoveAsync(Guid id)
        {
            var item = _storeContext.items.Find(id);

            if (item != null)
            {
                _storeContext.items.Remove(item);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(item);
        }
    }
}
