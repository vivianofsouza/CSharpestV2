using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Classes;
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
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public CartController(CartService cartService, CartItemService cartItemService)
        {
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


            //var allCartItems = await _cartItemService.GetAllAsync();

 

            // matches cartItems to those having user's cart's ID
            //var getUserCartItems = from cartItem in allCartItems 
            //                       where cartItem.CartId == userCart.Id
            //                       select cartItem;


            //List<Shopper> users = userLoader.loadUsers();
            //Shopper user = users.Find(x => x.AccountID == currUserID);

            //if (user == null)
            //{
            //    user = new Shopper("Example", "User", "exampleuser@email.com", "ExamplePW", "phone", "address", new Cart());
            //}

            //List<CartItem> cartItems = user.Cart.Items;
            return Ok(cartItems);
        }

        [HttpPost("AddItemToCart")]
        public void AddItemToCart([FromForm] Guid ItemID, [FromForm] int quantity)
        {
            //List<Item> items = inventoryLoader.loadInventory();
            ////Has been modified to not concern itself with getting current user back from frontend
            ////currUserID has been hard coded for phase 1
            //List<Shopper> users = userLoader.loadUsers();

            //Shopper user = users.Find(x => x.AccountID == currUserID); // get user from database using id
            ////ensure user was found
            //if (user == null) { Environment.Exit(0); }

            //Item item = items.Find(x => x.ItemId == ItemID); // get item from database using id
            ////ensure item was found
            //if (item == null) { Environment.Exit(0); }

            ////Create totalPrice of product
            //decimal totalPrice = item.Price * (decimal)quantity;

            ////Adds x number of item y to cart
            //if (user.Cart != null && quantity > 0 && item.Stock >= quantity)
            //{

            //    if (user.Cart.Items.Find(x => x.Item.ItemId == ItemID) == null)
            //    {
            //        //First instance of this item being in cart
            //        //Create CartItem
            //        CartItem cartItem = new CartItem(item, quantity, totalPrice);
            //        user.Cart.Items.Add(cartItem);
            //        user.Cart.Subtotal += cartItem.TotalPrice;
            //        userWriter.writeUser(user);

            //    }
            //    else
            //    {   // make sure user cannot add more than (stock minus what's already in cart)
            //        if ((user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity + quantity) <= item.Stock)
            //        {
            //            //Customer is adding more of this item to cart
            //            user.Cart.Items.Single(x => x.Item.ItemId == ItemID).Quantity += quantity;
            //            user.Cart.Items.Single(x => x.Item.ItemId == ItemID).TotalPrice += totalPrice;
            //            user.Cart.Subtotal += quantity * item.Price;
            //            userWriter.writeUser(user);
            //        }
            //    }

            //}
            //else
            //{

            //    if (user.Cart == null) { Environment.Exit(0); } // User added nothing to cart

            //    if (quantity < 0) { Environment.Exit(0); } // Should never happen but can't hurt

            //    if (item.Stock < quantity) { Environment.Exit(0); } // Not enough in stock to purchase that amount
            //}
        }

        // Remove an item from the cart
        //[HttpPost("RemoveItemFromCart")]
        //public void RemoveItem(Guid UserID, Guid ItemID, int quantity)
        //{
        //    _cartService.RemoveItem(UserID, ItemID, quantity);
        //}

    }
}
