using DomainProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationProduct.Interfaces
{
    public interface IAppProduct : IAppBase<Product>
    {
        Task<IEnumerable<Product>> FindByName(string name);
    }
}
