using CSharpestServer.Classes;
using CSharpestServer.Services;
using CSharpestServer.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CSharpestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService _checkoutService;
        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        // takes in a new card and then saves it to user object
        // POST: <CheckoutController>/address
        [HttpPost("takeCardInput")]
        public bool takeCardInput(CardCheckParams checkParams)
        {
            return _checkoutService.takeCardInput(checkParams);
        }


        // POST: <CheckoutController>/card
        [HttpPost("validateCardDetails")]
        public bool ValidateCardDetails(Card card)
        {
            return _checkoutService.ValidateCardDetails(card);
        }

        // POST: <CheckoutController>/checkout/validateAddress
        [HttpPost("validateAddress")]
        public bool validateAddress(String address)
        {
            Regex regex = new Regex("^[0-9]+$");
            string [] addrArray = address.Split(' ');

            if (regex.IsMatch(addrArray[0])) {
                return true;
            }

            return false;
        }

        // Adding address functionality either if we have time or in phase 2
        /*// POST: <CheckoutController>/address
        [HttpPost("{address}")]
        public bool ValidateShippingAddress(User user)
        {
            return true;
        }*/

        // POST: <CheckoutController>/purchase
        [HttpPost("purchase")]
        public bool purchase(Shopper user)
        {
            return _checkoutService.purchase(user);
        }

        [HttpPost("calculateTotal")]
        public Cart calculateTotal(Cart cart)
        {
            return _checkoutService.calculateTotal(cart);
        }

        // GET: api/<CartController>
        [HttpGet("ClearCartItems")]
        public void ClearCart(Guid UserID)
        {
            _checkoutService.ClearCart(UserID);
        }
    }
}
