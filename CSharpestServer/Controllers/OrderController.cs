using CSharpestServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using CSharpestServer.Services;

namespace CSharpestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: /placeOrder
        [HttpPost]
        public async Task<ActionResult<Order>> PlaceOrder(Cart cart, Guid userId, string cardNo, int month, int year, string name, int cVV, int zip, string address)
        {
            try
            {
                Card card = new Card(cardNo, month, year, name, cVV, zip);
                var order = await _orderService.PlaceOrder(cart, userId, card, address);
                return Ok(order);
            } catch
            {
                throw;
            }
            
        }
    }
}
