using DomainProduct.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainProduct.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepBase<TEntity> Repository;
        public ServiceBase(IRepBase<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public async Task<int> Add(TEntity entity)
        {
            return await this.Repository.Add(entity);
        }

        public void Dispose()
        {
            this.Repository.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.Repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await this.Repository.GetById(id);
        }

        public async Task Remove(TEntity entity)
        {
            await this.Repository.Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            await this.Repository.Update(entity);
        }
    }
}
