using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
//using CSharpestServer.Persistence;

namespace CSharpestServer.Services
{
    public class BundleService : IBundleService
    {
        private readonly StoreContext _storeContext;

        public BundleService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private Bundle GetInitialisedId(Bundle bundle)
        {
            if (bundle.Id == Guid.Empty) { bundle.Id = Guid.NewGuid(); }

            return bundle;
        }

        public Task AddAsync(Bundle bundle)
        {
            bundle = GetInitialisedId(bundle);
            _storeContext.bundles.Add(bundle);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<Bundle> bundles)
        {
            foreach (var i in bundles)
            {
                Bundle bundle = GetInitialisedId(i);
                _storeContext.Add(bundle);
            }
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Bundle>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.bundles.AsEnumerable());
        }

        public Bundle? GetById(Guid id)
        {
            return _storeContext.bundles.Find(id);
        }

        public Task<Bundle?> GetByIdAsync(Guid id)
        {
            Bundle? bundle = _storeContext.bundles.Find(id);
            return Task.FromResult(bundle);
        }

        public Task RemoveAsync(Guid id)
        {
            var bundle = _storeContext?.bundles.Find(id);

            if (bundle != null)
            {
                _storeContext.bundles.Remove(bundle);
                _storeContext.SaveChanges();
            }
            return Task.FromResult(bundle);
        }
    }
}
