using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public Task ChangeStockAsync(Guid itemId, int quantity, bool addOrRemove)
        {
            Item? _item = _storeContext.items.Find(itemId);
            if (_item == null)
            {
                throw new InvalidOperationException($"Item with ID {itemId} not found.");
            }

            if (addOrRemove) //True: add
            {
                _item.Stock += quantity;
            }
            else //False: remove
            {
                if (quantity > _item.Stock) { _item.Stock = 0; }
                else { _item.Stock -= quantity; }
            }

            _storeContext.SaveChanges();
            return Task.FromResult(_item);
        }

        public Task ChangePriceAsync(Guid itemId, decimal price)
        {
            Item? _item = _storeContext.items.Find(itemId);
            if (_item == null)
            {
                throw new InvalidOperationException($"Item with ID {itemId} not found.");
            }

            if (price >= 0)
            {
                _item.Price = price;
            }

            //CATCH FOR NEGATIVE PRICE: RETURN NOTE?

            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddItem(Item item)
        {
            item = GetInitialisedId(item);
            if (_storeContext.items == null)
            {
                return Task.FromException(new NullReferenceException());
            }

            try {
                _storeContext.items.Add(item);
                _storeContext.SaveChanges();

            } catch (Exception e) {
                return Task.FromException(e);
            }

            return Task.CompletedTask;
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

        public Task RemoveItem(Guid id)
        {
            var item = _storeContext.items.Find(id);

            if (item == null)
            {
                return Task.FromException(new NullReferenceException());
            }

            try
            {
                _storeContext.items.Remove(item);
                _storeContext.SaveChanges();

            }   catch (Exception e)
            {
                return Task.FromException(e);
            }

            return Task.CompletedTask;
        }
    }
}
