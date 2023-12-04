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

        //GET: <ItemController>/GetAllItems
       [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllAsync();

            var sorted = from item in items
                         orderby item.Price
                         select item;

            return Ok(sorted);
        }
    }
}
