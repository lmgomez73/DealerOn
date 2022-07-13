using DealerOn.Cache.Interfaces;
using DealerOn.Models.Interfaces;
using DealerOn.Repository.Interfaces;

namespace DealerOn.Repository
{
    public class SaleRepository : GenericRepository<ISale>, ISalesRepository
    {
        public SaleRepository(ICacheService cacheService) : base(cacheService)
        {

        }
    }
}
