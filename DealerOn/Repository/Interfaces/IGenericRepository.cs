using DealerOn.Models.Interfaces;

namespace DealerOn.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : IIdentifiable
    {
        T GetById(int id);
        ICollection<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
