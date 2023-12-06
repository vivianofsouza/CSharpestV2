using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Services;
using CSharpestServer.Services.Interfaces;
using CSharpestServer.Models;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public CartController(StoreContext context, CartService cartService, CartItemService cartItemService)
        {
            this._context = context;
            this._cartService = cartService;
            this._cartItemService = cartItemService;
        }

        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems(Guid UserID)
        {
            // gets a user's carts (as a list but really only one) + all Cart Items in DB
            var carts = await _cartService.GetByUserAsync(UserID);

            // obtains cart instance for user
            var userCart = carts.First();

            // gets all items belonging to this user's cart
            var cartItems = await _cartItemService.GetByCartAsync(userCart.Id);

            return Ok(cartItems);
        }

        [HttpPost("AddItemToCart")]
        public async Task<IActionResult> AddItemToCart([FromForm] Guid ItemId, [FromForm] Guid CartId, [FromForm] int quantity) //[FromForm] Guid ItemID, [FromForm] int quantity)
        {
            try
            {
                if (CartItemExists(ItemId))
                {
                    var cartItem = _context.cartItems?.FirstOrDefault(e => e.ItemId == ItemId);
                    await _cartItemService.ChangeQuantityAsync(cartItem.Id, ItemId, quantity, true);
                }
                else
                {
                    await _cartItemService.AddAsync(ItemId, CartId, quantity);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpPatch("ChangeStock")]
        public async Task<IActionResult> ChangeQuantityAsync(Guid cartId, Guid itemId, int quantity, bool add)
        {
            try
            {
                await _cartItemService.ChangeQuantityAsync(cartId, itemId, quantity, add);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemFromCart(Guid itemId, Guid cartId)
        {
            try
            {
                await _cartItemService.RemoveAsync(itemId, cartId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        //[HttpDelete]
        //public async Task<IActionResult> ClearCart(Guid cartId)
        //{
        //    try
        //    {
        //        await _cartItemService.ClearCartAsync(cartId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok();
        //}

        private bool CartItemExists(Guid id)
        {
            // the itemId is recognisable
            return (_context.cartItems?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }

    }
}
