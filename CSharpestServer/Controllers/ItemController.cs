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
        public async Task<IActionResult> ChangeStock(Guid itemId, int quantity, bool add)
        {
            try {
                await _itemService.ChangeStockAsync(itemId, quantity, add);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
        public async Task<IActionResult> ChangePrice(Guid itemId, decimal price)
        {
            try
            {
                await _itemService.ChangePriceAsync(itemId, price);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            try {
                await _itemService.AddItem(item);
            } catch(Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    }
}
