using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace CSharpestServer.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreContext _storeContext;
        private readonly IItemService _itemService;

        public OrderService(StoreContext storeContext, ItemService itemService)
        {
            _storeContext = storeContext;
            this._itemService = itemService;
        }

        public Task<Order> PlaceOrder(Cart cart, Guid userId, Card card, string address)
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

                var cost = ManageStockAndCost(cart);
                if (cost == 0.0M)
                {
                    throw new InvalidOperationException($"Error manipulating item stocks");
                } else
                {
                    order.TotalCost = cost;
                }

                //NEED TO CLEAR CART

                AddOrder(order);
                return Task.FromResult(order);

            } catch
            {
                throw;
            }
            
        }

        public Task AddOrder(Order order)
        {
            try
            {
                order = GetInitialisedId(order);
                _storeContext.orders.Add(order);
                _storeContext.SaveChanges();
                return Task.CompletedTask;
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
            /*Regex regex = new Regex("^[0-9]+$");
            string[] addrArray = address.Split(' ');

            if (regex.IsMatch(addrArray[0]))
            {
                return true;
            }*/

            return true;
        }

        // Removes stock amounts from the store's inventory upon purchase
        private decimal ManageStockAndCost(Cart cart)
        {
            var inCart = _storeContext.cartItems.AsEnumerable();
            var stock = _storeContext.items.AsEnumerable();
            var items = from i in inCart
                        where i.CartId == cart.Id
                        select i;
            var cost = 0.0M;

            foreach (CartItem item in items)
            {
                try
                {
                    _itemService.ChangeStock(item.ItemId, item.Quantity, false);
                    cost += item.TotalPrice;
                }
                catch
                {
                    return 0.0M;
                }
            }
            _storeContext.SaveChanges();
            return cost;
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
