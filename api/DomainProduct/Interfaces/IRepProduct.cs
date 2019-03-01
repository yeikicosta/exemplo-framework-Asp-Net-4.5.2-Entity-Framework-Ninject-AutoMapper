using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainProduct.Interfaces
{
    public interface IRepProduct : IRepBase<Product>
    {
        Task<IEnumerable<Product>> FindByName(string name);
    }
}
