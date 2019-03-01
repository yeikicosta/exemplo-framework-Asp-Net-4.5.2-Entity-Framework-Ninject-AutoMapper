using ApplicationProduct.Interfaces;
using DomainProduct;
using DomainProduct.Interfaces;

namespace ApplicationProduct
{
    public class AppCategory : AppBase<Category>, IAppCategory
    {
        private readonly IServiceCategory ServiceCategory;
        public AppCategory(IServiceCategory ServiceCategory) : base(ServiceCategory)
        {
            this.ServiceCategory = ServiceCategory;
        }

    }
}
