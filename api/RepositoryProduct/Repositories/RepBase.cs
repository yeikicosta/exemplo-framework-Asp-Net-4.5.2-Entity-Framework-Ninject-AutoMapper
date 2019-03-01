using DomainProduct.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryProduct.Repositories
{
    public class RepBase<TEntity> : IRepBase<TEntity> where TEntity : class, IEntity
    {
        readonly protected ProductContext dbProductContext = new ProductContext();

        public virtual async Task<int> Add(TEntity entity)
        {
            try
            {
                dbProductContext.Set<TEntity>().Add(entity);
                await dbProductContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
            dbProductContext.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(() => dbProductContext.Set<TEntity>().ToList());
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbProductContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            dbProductContext.Entry(entity).State = EntityState.Deleted;
            dbProductContext.Set<TEntity>().Remove(entity);
            await dbProductContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            dbProductContext.Entry(entity).State = EntityState.Modified;
            await dbProductContext.SaveChangesAsync();
        }

    }
}
