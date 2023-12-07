using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Helpers;

namespace CSharpestServer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly StoreContext _storeContext;

        public CartItemService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Task AddToCart(Guid itemId, Guid cartId, int quantity)
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

                Cart? _cart = _storeContext.carts.Find(cartId);
                if (_cart != null)
                {
                    UpdateCartTotals(_cart);
                    _storeContext.SaveChanges();
                }

                return Task.CompletedTask;
            } catch
            {
                throw;
            }
            
        }

        public Task ChangeQuantity(Guid cartId, Guid cartItemId, int Quantity, bool Add)
        {
            
            CartItem? _item = _storeContext.cartItems.Find(cartItemId);
            Cart? _cart = _storeContext.carts.Find(cartId);

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
                    _item.TotalPrice = calculateTotal(_item.Quantity, unit_cost, bundle);
                }
            }   else
            {
                if (Quantity >= _item.Quantity)
                {
                    // quantity will be zeroed which is the same as removing it
                    _storeContext.cartItems.Remove(_item);
                }
                else
                {
                    _item.Quantity -= Quantity;
                    _item.TotalPrice = calculateTotal(_item.Quantity, unit_cost, bundle);
                }
            }
            _storeContext.SaveChanges();

            UpdateCartTotals(_cart);
            _storeContext.SaveChanges();

            return Task.CompletedTask;

        }

        public Task<IEnumerable<CartItem>?> GetItemsByCart(Guid cartId)
        {
            var items = _storeContext.cartItems.Where(item => item.CartId == cartId).Select(i => i).ToList();
            return Task.FromResult<IEnumerable<CartItem>?>(items);
        }

        public Task<Cart?> GetCartByUser(Guid userId)
        {
            var cart = _storeContext.carts.Where(c => c.userId == userId).ToList().FirstOrDefault();
            return Task.FromResult<Cart?>(cart);
        }

        public Task ClearCart(Guid cartId)
        {
            try 
            {
                var items = _storeContext.cartItems.Where(item => item.CartId == cartId).AsEnumerable();
                items = items.ToList();

                foreach (CartItem item in items)
                {
                    if (item != null)
                    {
                        _storeContext.cartItems.Remove(item);
                    }
                }
                _storeContext.SaveChanges();

                Cart? _cart = _storeContext.carts.Find(cartId);
                UpdateCartTotals(_cart);
                _storeContext.SaveChanges();

                return Task.FromResult(items);
            }
            catch
            {
                throw;
            }
        }


        public Task RemoveFromCart(Guid itemId, Guid cartId)
        {
            try
            {
                //CartItem item = _storeContext?.cartItems.FindAsync(cartId, id).Result;
                CartItem? item = _storeContext.cartItems
                    .Select(i => i)
                    .Where(i => i.CartId == cartId && i.ItemId == itemId)
                    .FirstOrDefault();

                if (item != null)
                {
                    _storeContext.cartItems.Remove(item);
                    _storeContext.SaveChanges();

                    Cart? _cart = _storeContext.carts.Find(cartId);
                    UpdateCartTotals(_cart);
                    _storeContext.SaveChanges();

                    return Task.CompletedTask;
                }

                throw new InvalidOperationException($"Item with ID {itemId} not found in User {cartId}'s cart."); ;
            }
            catch 
            {
                throw;
            }
        }

        //PRIVATE HELPER SERVICES
        private CartItem GetInitialisedId(CartItem item)
        {
            if (item.Id == Guid.Empty) { item.Id = Guid.NewGuid(); }
            return item;
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

        private Cart UpdateCartTotals(Cart cart)
        {
            var items = GetItemsByCart(cart.Id);
            
            if (cart != null)
            { 
                if (items.Result != null)
                {
                    cart.Subtotal = 0;
                    cart.Tax = 0;
                    cart.TotalPrice = 0;
                    foreach (CartItem ci in items.Result)
                    {
                        cart.Subtotal += ci.TotalPrice;
                        cart.Tax += ci.TotalPrice * 0.08M;
                    }
                    cart.TotalPrice = cart.Subtotal + cart.Tax;
                    cart.TotalPrice += 5.99M;
                    return cart;
                } else
                {
                    cart.Subtotal = 0;
                    cart.Tax = 0;
                    cart.TotalPrice = 0;
                    return cart;
                }
                
            } else
            {
                return cart;
            }
        }
    }
}
