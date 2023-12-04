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
    public class ItemController : Controller
    {
        //ItemService itemService;
        private readonly IItemService _itemService;

        //InventoryLoader inventoryLoader = new InventoryLoader(@".\Data\inventory.json");
        SortedSet<Item> items;

        public ItemController(ItemService itemService)
        {
            this._itemService = itemService;
        }

        //GET: <ItemController>/GetAllItems
       [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllAsync();

            List<Item> result = items.ToList();
            return Ok(result);
        }
    }
}
