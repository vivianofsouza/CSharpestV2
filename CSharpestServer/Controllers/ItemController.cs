using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Models;
//using CSharpestServer.Services.phase1;
using CSharpestServer.Services;
using CSharpestServer.Services.Interfaces;
using System.Linq;
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
    }
}
