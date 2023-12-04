using CSharpestServer.Models;

namespace CSharpestServer.Services.Interfaces
{
    public interface IBundleService
    {
        Task AddAsync(Bundle bundle);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<Bundle>> GetAllAsync();
        Task<Bundle?> GetByIdAsync(Guid id);
        Bundle? GetById(Guid id);
        Task AddRangeAsync(IEnumerable<Bundle> items);
    }
}