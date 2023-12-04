using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IItemService
    {
        Task AddAsync(Item itemId); // add to db
        Task RemoveAsync(Guid id);// remove from db
        Task ChangeStockAsync(Guid itemId, int Quantity, string AddOrRemove); // change stock
        Task<IEnumerable<Item>> GetAllAsync(); // see all items in db
        Task<Item?> GetByIdAsync(Guid id); // get an item async
        Item? GetById(Guid id); // get an item
        Task AddRangeAsync(IEnumerable<Item> items); // get a "list" of items
    }
}