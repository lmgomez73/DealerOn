using DealerOn.Cache.Interfaces;
using DealerOn.Models.Interfaces;
using DealerOn.Repository.Interfaces;

namespace DealerOn.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IIdentifiable
    {
        protected string _cacheKey = $"{typeof(T)}";
        private readonly ICacheService _cacheService;
        public GenericRepository(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public virtual T GetById(int id)
        {
            if (!_cacheService.TryGet(_cacheKey, out ICollection<T> cachedList))
            {
                throw new Exception($"Unable to find {_cacheKey} collection in memory");
            }
            return cachedList.FirstOrDefault(x => x.Id == id);
        }
        public ICollection<T> GetAll()
        {
            if (!_cacheService.TryGet(_cacheKey, out ICollection<T> cachedList))
            {
                cachedList = new List<T>();
                _cacheService.Set(_cacheKey, cachedList);
            }
            return cachedList;
        }
        public T Add(T entity)
        {
            if (!_cacheService.TryGet(_cacheKey, out ICollection<T> cachedList))
            {
                entity.Id = 1;
                cachedList = new List<T>() { entity };
                _cacheService.Set(_cacheKey, cachedList);
                return entity;
            }
            int id = cachedList.Max(x=> x.Id);
            entity.Id = ++id;
            cachedList.Add(entity);
            return entity;
        }
        public void Update(T entity)
        {
            if (!_cacheService.TryGet(_cacheKey, out IEnumerable<T> cachedList))
            {
                throw new Exception($"Unable to find {_cacheKey} collection in memory");
            }
            var updatedEntity= cachedList.FirstOrDefault(x => x.Id == entity.Id);
            if (updatedEntity != null)
            updatedEntity = entity;
        }
        public void Delete(T entity)
        {
            if (!_cacheService.TryGet(_cacheKey, out ICollection<T> cachedList))
            {
                throw new Exception($"Unable to find {_cacheKey} collection in memory");
            }
            cachedList.Remove(entity);
        }

    }
}
