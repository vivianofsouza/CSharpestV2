using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSharpestServer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly StoreContext _storeContext;

        public CartItemService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public CartItem GetInitialisedId(CartItem item)
        {
            if (item.Id == Guid.Empty) { item.Id = Guid.NewGuid();}
            return item;
        }

        public Task AddAsync(CartItem item)
        {
            item = GetInitialisedId(item);
            _storeContext.cartItems.Add(item);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<CartItem> items)
        {
            foreach (var i in items)
            {
                CartItem item = GetInitialisedId(i);
                _storeContext.Add(item);
            }
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        
        }

        public Task ChangeQuantityAsync(Guid itemId, int Quantity, string AddOrRemove)
        {
            CartItem? _item = _storeContext.cartItems.Find(itemId);
            if (_item == null)
            { 
                throw new InvalidOperationException($"CartItem with ID {itemId} not found."); 
            }
            var unit_cost = _storeContext.items.Find(_item.ItemId).Price;

            if (AddOrRemove == "add")//addOrRemove.Equals("add", StringComparison.OrdinalIgnoreCase))
            {
                // find the stock
                int stock = _storeContext.items.Find(_item.ItemId).Stock;
                // check if we have that much in stock
                if (stock < Quantity + _item.Quantity)
                {
                    throw (new InvalidOperationException("There are not that many of this item in stock."));
                }
                else 
                { 
                    _item.Quantity += Quantity;
                    _item.TotalPrice = Quantity * unit_cost;
                } 
            }
            
            if (AddOrRemove == "remove")
            {
                if (Quantity > _item.Quantity)
                {
                    // quantity will be zeroed which is the same as removing it
                    _storeContext.cartItems.Remove(_item);
                }
                else 
                {
                    _item.Quantity -= Quantity;
                    _item.TotalPrice = Quantity * unit_cost;
                }
            }
            _storeContext.SaveChanges();
            return Task.FromResult(_item);

        }
        public Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.cartItems.AsEnumerable());
        }

        public Task<IEnumerable<CartItem>?> GetByCartAsync(Guid cartId)
        {
            var items = _storeContext.cartItems.Where(item => item.CartId == cartId).ToList();
            return Task.FromResult<IEnumerable<CartItem>?>(items);
        }

        public CartItem? GetById(Guid id)
        {
            return _storeContext.cartItems.Find(id);
        }

        public Task<CartItem?> GetByIdAsync(Guid id)
        {
            CartItem? item = _storeContext.cartItems.Find(id);
            return Task.FromResult(item);
        }

        public Task RemoveAsync(Guid id)
        {
            var item = _storeContext?.cartItems.Find(id);

            if (item != null)
            {
                _storeContext.cartItems.Remove(item);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(item);
        }
    }
}
