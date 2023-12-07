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
        private readonly ICartItemService _cartItemService;
        private readonly IItemService _itemService;

        public CartController(StoreContext context, CartItemService cartItemService, ItemService itemService)
        {
            this._context = context;
            this._cartItemService = cartItemService;
            this._itemService = itemService;
        }

        // GET: api/<CartController>
        // Researched returning anonymous type from function and considered creating 'returnedCart' class in service
        // Decided although it does not follow our typical Controller -> Service format, it is far less code this way
        // Hence this endpoint is a little messier but it works fine
        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems(Guid UserID)
        {
            try
            {
                // gets a user's carts (as a list but really only one) + all Cart Items in DB
                var cart = await _cartItemService.GetCartByUser(UserID);

                // gets all items belonging to this user's cart
                var cartItems = await _cartItemService.GetItemsByCart(cart.Id);
                var allItems = await _itemService.GetAllAsync();

                var inCart = (from cartItem in cartItems
                              join item in allItems
                              on cartItem.ItemId equals item.Id
                              select new
                              {
                                  id = item.Id,
                                  name = item.Name,
                                  imageURL = item.ImageURL,
                                  unitPrice = item.Price,
                                  quantity = cartItem.Quantity,
                                  totalPrice = cartItem.TotalPrice
                              }).ToList();

                return Ok(inCart);

            } catch
            {
                return Ok(null);
            }
            
        }

        [HttpPost("AddItemToCart")]
        public async Task<IActionResult> AddItemToCart([FromForm] Guid ItemId, [FromForm] Guid CartId, [FromForm] int quantity)
        {
            try
            {
                var cartItem = CartItemExists(ItemId, CartId);
                if (cartItem != null)
                {
                    await _cartItemService.ChangeQuantity(CartId, cartItem.Id, quantity, true);
                }
                else
                {
                    await _cartItemService.AddToCart(ItemId, CartId, quantity);
                }
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [HttpPatch("ChangeQuantity")]
        public async Task<IActionResult> ChangeQuantity([FromForm] Guid itemId, [FromForm] Guid cartId, [FromForm] int quantity, [FromForm] bool add)
        {
            try
            {
                var cartItem = CartItemExists(itemId, cartId);
                await _cartItemService.ChangeQuantity(cartId, cartItem.Id, quantity, add);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("RemoveFromCart")]
        public async Task<IActionResult> RemoveItemFromCart([FromForm] Guid itemId, [FromForm] Guid cartId)
        {
            try
            {
                await _cartItemService.RemoveFromCart(itemId, cartId);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart([FromForm] Guid cartId)
        {
            try
            {
                await _cartItemService.ClearCart(cartId);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        //Private controller service to decide which service to call
        private CartItem? CartItemExists(Guid itemId, Guid cartId)
        {
            // Does this cart contain any quantity of this item
            return _context.cartItems?
                .Select(i => i)
                .Where(i => cartId == i.CartId)
                .FirstOrDefault(e => e.ItemId == itemId);
        }

    }
}
