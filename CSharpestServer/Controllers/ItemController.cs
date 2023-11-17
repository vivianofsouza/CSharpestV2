using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Classes;
using CSharpestServer.Services;
namespace CSharpestServer.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        ItemService itemService;
        InventoryLoader inventoryLoader = new InventoryLoader(@".\Data\inventory.json");
        SortedSet<Item> items;

        public ItemController(ItemService _itemService)
        {
            itemService = _itemService;
            //items = inventoryLoader.loadInventorySorted();
        }

        // GET: <ItemController>/GetAllItems
        [HttpGet("GetAllItems")]
        public SortedSet<Item> GetAllItems()
        {
            return itemService.GetAllItems();
        }
    }
}
