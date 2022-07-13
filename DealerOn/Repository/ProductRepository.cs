using DealerOn.Cache.Interfaces;
using DealerOn.Models.Interfaces;
using DealerOn.Repository.Interfaces;

namespace DealerOn.Repository
{
    public class ProductRepository : GenericRepository<IProduct>, IProductRepository
    {
        
        public ProductRepository(ICacheService cacheService) : base(cacheService)
        {
            _cacheKey = "Product";
        }
    }
}
