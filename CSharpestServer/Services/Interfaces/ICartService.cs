using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface ICartService
    {
        Task AddAsync(Guid cartId, Guid userId);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart?> GetByIdAsync(Guid cartId);
        Cart? GetById(Guid id);
        Task<IEnumerable<Cart>?> GetByUserAsync(Guid userId);
    }
}