using DomainProduct.Interfaces;

namespace DomainProduct.Services
{
    public class ServiceCategory : ServiceBase<Category>, IServiceCategory
    {
        public ServiceCategory(IRepBase<Category> Repository) : base(Repository)
        {
        }
    }
}
