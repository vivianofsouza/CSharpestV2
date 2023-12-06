using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public Task AddAsync(Guid itemId, Guid cartId, int quantity)
        {
            try
            {
                var my_item = _storeContext.items.Find(itemId);
                CartItem item = GetInitialisedId(new CartItem());
                item.ItemId = itemId;
                item.CartId = cartId;
                item.Quantity = quantity;
                Bundle bundle = _storeContext.bundles.Find(itemId);
                item.TotalPrice = calculateTotal(quantity, my_item.Price, bundle);

                _storeContext.cartItems.Add(item);
                _storeContext.SaveChanges();

                return Task.CompletedTask;
            } catch
            {
                throw;
            }
            
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

        public Task ChangeQuantityAsync(Guid cartId, Guid cartItemId, int Quantity, bool Add)
        {
            
            CartItem? _item = _storeContext.cartItems.Find(cartItemId);

            if (_item == null || _item.CartId != cartId)
            {
                throw new InvalidOperationException($"CartItem with ID {cartItemId} not found in cart.");
            }
            Item my_item = _storeContext.items.Find(_item.ItemId);
            var unit_cost = my_item.Price;
            var bundle = _storeContext.bundles.Find(my_item.bundleId);

            if (Add)
            {
                // find the stock
                int stock = my_item.Stock;
                // check if we have that much in stock
                if (stock < Quantity + _item.Quantity)
                {
                    throw (new InvalidOperationException("There are not that many of this item in stock."));
                }
                else
                {
                    _item.Quantity += Quantity;
                    _item.TotalPrice = calculateTotal(Quantity, unit_cost, bundle);
                }
            }

            else
            {
                if (Quantity > _item.Quantity)
                {
                    // quantity will be zeroed which is the same as removing it
                    _storeContext.cartItems.Remove(_item);
                }
                else
                {
                    _item.Quantity -= Quantity;
                    _item.TotalPrice = calculateTotal(Quantity, unit_cost, bundle);
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

        public Task ClearCartAsync(Guid cartId)
        {
            try 
            {
                var items = _storeContext.cartItems.Where(item => item.CartId == cartId);

                foreach (CartItem item in items)
                {
                    if (item != null)
                    {
                        _storeContext.cartItems.Remove(item);
                    }
                }
                _storeContext.SaveChanges();
                return Task.FromResult(items);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public Task RemoveAsync(Guid id, Guid cartId)
        {
            try
            {
                CartItem item = _storeContext?.cartItems.FindAsync(cartId, id).Result;
                //CartItem item = _storeContext?.cartItems
                //    .Where(cartItem => cartItem.CartId == cartId && cartItem.Id == id)
                //    .FirstOrDefaultAsync().Result;

                if (item != null)
                {
                    _storeContext?.cartItems.Remove(item);
                    _storeContext.SaveChanges();
                }
                return Task.FromResult(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private decimal calculateTotal(int quantity, decimal unit_cost, Bundle bundle)
        {
            if (bundle != null)
            {
                if (bundle.Name == "bogo")
                {
                    return ((quantity % 2) * unit_cost) + (unit_cost * (quantity / 2));
                }
            }
            return unit_cost * quantity;
        }
    }
}
