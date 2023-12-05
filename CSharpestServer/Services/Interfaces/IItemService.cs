using CSharpestServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpestServer.Services.Interfaces
{
    public interface IItemService
    {
        Task RemoveItem(Guid id);// remove from db
        Task ChangeStockAsync(Guid itemId, int Quantity, bool Add); // change stock
        Task ChangePriceAsync(Guid itemId, decimal Price); // change price
        Task AddItem(Item item); // create an item
        Task<IEnumerable<Item>> GetAllAsync(); // see all items in db
    }
}