using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainProduct.Interfaces
{
    public interface IServiceProduct : IServiceBase<Product>
    {
        Task<IEnumerable<Product>> FindByName(string name);
    }
}
