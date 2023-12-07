using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace CSharpestServer.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreContext _storeContext;
        private readonly IItemService _itemService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderItemService _orderItemService;

        public OrderService(StoreContext storeContext, ItemService itemService, CartItemService cartItemService, OrderItemService orderItemService)
        {
            _storeContext = storeContext;
            this._itemService = itemService;
            this._cartItemService = cartItemService;
            this._orderItemService = orderItemService;
        }

        public Task<Order> PlaceOrder(Guid userId, Card card, string address)
        {
            try
            {
                Order order = new Order(userId, card, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), address, 5.99M);

                if (!CardInput(card))
                {
                    throw new InvalidOperationException($"Card validation error");
                }
                AddCard(card);

                if (!ValidateAddress(address))
                {
                    throw new InvalidOperationException($"Address validation error");
                }

                var cart = _cartItemService.GetCartByUser(userId).Result;
                if (cart == null)
                {
                    throw new InvalidOperationException($"Couldn't find cart associated with User {userId}");
                }

                try
                {
                    var cost = ManageStockAndCost(cart);
                    if (cost.Result == 0.0M)
                    {
                        throw new InvalidOperationException($"No items found");
                    } else
                    {
                        order.TotalCost = cost.Result;
                    }

                } catch
                {
                    throw;
                }               
                
                AddOrder(order, cart);
                _cartItemService.ClearCart(cart.Id);
                return Task.FromResult(order);

            } catch
            {
                throw;
            }
            
        }

        // Creates an order and all of the Order Items, adds them to db
        private async Task AddOrder(Order order, Cart cart)
        {
            try
            {
                var inCart = _storeContext.cartItems.AsEnumerable();
                var items = from i in inCart
                            where i.CartId == cart.Id
                            select i;

                var inventory = _storeContext.items.AsEnumerable();
                foreach (CartItem cItem in items)
                {
                    try
                    {
                        Item? realItem = _storeContext.items.Find(cItem.ItemId);
                        if (realItem != null)
                        {
                            OrderItem newOI = new OrderItem(order.Id, realItem.Id, realItem.bundleId, cItem.Quantity, cItem.TotalPrice);
                            await _orderItemService.AddAsync(newOI);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }

                order = GetInitialisedId(order);
                _storeContext.orders.Add(order);
                _storeContext.SaveChanges();
                return;
            } catch
            {
                throw;
            }
            
        }

        // ORDER PLACEMENT SERVICES
        private bool CardInput(Card card)
        {
            // checks card nullity
            if (card == null)   {return false;}

            // checks for valid credit card number length
            if (card.Number.ToString().Length > 19 || card.Number.ToString().Length < 16)   {return false;}

            // checks for valid month
            if (card.Month < 1 || card.Month > 12)  {return false;}

            // checks for valid year
            if (card.Year <= 2022 || card.Year > 2100)  {return false;}

            //checks for valid CVV
            if (card.CVV.ToString().Length! > 4)    {return false;}

            //checks for valid zipcode
            if (card.ZipCode.ToString().Length != 5) { return false; }

            return true;
        }
        private bool AddCard(Card card)
        {
            if (!_storeContext.cards.Contains(card))
            {
                _storeContext.cards.Add(card);
                _storeContext.SaveChanges();
            }
            return true;
        }
        private bool ValidateAddress(string address)
        {
            var regex = new Regex(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$");

            if (regex.IsMatch(address))
            {
                return true;
            }

            return false;
        }

        // Removes stock amounts from the store's inventory upon purchase
        private Task<decimal> ManageStockAndCost(Cart cart)
        {
            var inCart = _storeContext.cartItems.AsEnumerable();
            var stock = _storeContext.items.AsEnumerable();
            var items = from i in inCart
                        where i.CartId == cart.Id
                        select i;
            decimal cost = 0.0M;
            items = items.ToList();

            foreach (CartItem item in items)
            {
                try
                {
                    _itemService.ChangeStock(item.ItemId, item.Quantity, false);
                    cost += item.TotalPrice;
                }
                catch
                {
                    throw;
                }
            }

            cost += Math.Round(cost * 0.08M, 2);
            cost += 5.99M;

            _storeContext.SaveChanges();
            return Task.FromResult(cost);
        }

        // Generates an order ID
        private Order GetInitialisedId(Order order)
        {
            if (order.Id == Guid.Empty) { order.Id = Guid.NewGuid(); }

            return order;
        }

        public Task<IEnumerable<Order>?> GetOrderHistory(Guid userId)
        {
            var orders = _storeContext.orders.Where(order => order.UserId == userId).ToList();
            return Task.FromResult<IEnumerable<Order>?>(orders);
        }
        
        // NON-CHECKOUT CARD RELATED ******
        public Task RemoveCard(string card_number)
        {
            var card = _storeContext?.cards.Find(card_number);

            _storeContext.cards.Remove(card);
            _storeContext.SaveChanges();
            return Task.FromResult(card);
        }
       
    }
}
