using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainProduct.Interfaces
{
    public interface IRepBase<TEntity> where TEntity : class, IEntity
    {
        Task<int> Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        void Dispose();
    }
}
