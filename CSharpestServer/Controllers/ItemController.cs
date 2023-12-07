using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Models;
//using CSharpestServer.Services.phase1;
using CSharpestServer.Services;
using CSharpestServer.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSharpestServer.Controllers

{

    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(ItemService itemService)
        {
            this._itemService = itemService;
        }

       [HttpGet("GetAllItemsPriceSort")]
        public async Task<IActionResult> GetAllItemsByPrice()
        {
            var items = await _itemService.GetAllAsync();

            var sorted = from item in items
                         orderby item.Price
                         select item;

            return Ok(sorted);
        }

        [HttpGet("GetAllItemsAZSort")]
        public async Task<IActionResult> GetAllItemsByAlphabet()
        {
            var items = await _itemService.GetAllAsync();

            var sorted = from item in items
                         orderby item.Name
                         select item;

            return Ok(sorted);
        }

        [HttpGet("GetAllItemsStockSort")]
        public async Task<IActionResult> GetAllItemsByStock()
        {
            var items = await _itemService.GetAllAsync();

            var sorted = from item in items
                         orderby item.Stock
                         select item;

            return Ok(sorted);
        }

        [HttpPatch("ChangeStock")]
        public async Task<IActionResult> ChangeStock([FromForm] Guid itemId, [FromForm] int quantity, [FromForm] bool add)
        {
            try {
                await _itemService.ChangeStock(itemId, quantity, add);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [HttpGet("GetAllItemsOnSale")]
        public async Task<IActionResult> GetAllItemsOnSale()
        {
            var items = await _itemService.GetAllAsync();

            var sorted = from item in items
                         where item.bundleId != null
                         orderby item.Name
                         select item;

            return Ok(sorted);
        }


        [HttpPatch("ChangePrice")]
        public async Task<IActionResult> ChangePrice([FromForm] Guid itemId, [FromForm] decimal price)
        {
            try
            {
                await _itemService.ChangePriceAsync(itemId, price);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromForm] string name, [FromForm] string desc, [FromForm] decimal price, [FromForm] int stock, [FromForm] Guid? bundle, [FromForm] string url)
        {
            try {
                Item item = new Item(name, desc, price, stock, bundle, url);
                await _itemService.AddItem(item);

            } catch
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItem(Guid itemId)
        {
            try
            {
                await _itemService.RemoveItem(itemId);
            }
            catch
            {
                throw;
            }
            return Ok();
        }
    }
}
