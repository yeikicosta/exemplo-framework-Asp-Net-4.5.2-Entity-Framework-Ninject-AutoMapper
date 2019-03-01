using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationProduct.Interfaces;
using DomainProduct.Interfaces;

namespace ApplicationProduct
{
    public class AppBase<TEntity> : IAppBase<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IServiceBase<TEntity> ServiceBase;

        public AppBase(IServiceBase<TEntity> ServiceBase)
        {
            this.ServiceBase = ServiceBase;
        }

        public virtual async Task<int> Add(TEntity entity)
        {
            return await this.ServiceBase.Add(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await this.ServiceBase.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.ServiceBase.GetAll();
        }

        public async Task Update(TEntity entity)
        {
            await this.ServiceBase.Update(entity);
        }

        public async Task Remove(TEntity entity)
        {
            await this.ServiceBase.Remove(entity);
        }

        public void Dispose()
        {
            this.ServiceBase.Dispose();
        }
    }
}
