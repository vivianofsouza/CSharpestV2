using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface ICardService
    {
        Task AddAsync(Card card);
        Task RemoveAsync(string cardNo);
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card?> GetByNumAsync(string cardNo);
        Card? GetByNum(string cardNo);
        Task AddRangeAsync(IEnumerable<Card> cards);
    }
}
