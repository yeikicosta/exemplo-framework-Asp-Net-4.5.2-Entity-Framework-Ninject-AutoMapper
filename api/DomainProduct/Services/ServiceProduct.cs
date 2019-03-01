using System.Collections.Generic;
using System.Threading.Tasks;
using DomainProduct.Interfaces;

namespace DomainProduct.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        readonly private IRepProduct RepositoryProduct; 
        public ServiceProduct(IRepProduct RepositoryProduct) : base(RepositoryProduct)
        {
            this.RepositoryProduct = RepositoryProduct;
        }

        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            return await this.RepositoryProduct.FindByName(name);
        }
    }
}
