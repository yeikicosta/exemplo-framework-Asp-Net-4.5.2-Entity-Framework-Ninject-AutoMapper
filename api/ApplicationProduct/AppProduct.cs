using ApplicationProduct.Interfaces;
using DomainProduct;
using DomainProduct.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationProduct
{
    public class AppProduct : AppBase<Product>, IAppProduct
    {
        private readonly IServiceProduct ServiceProduct;
        public AppProduct(IServiceProduct ServiceProduct) : base(ServiceProduct)
        {
            this.ServiceProduct = ServiceProduct;
        }

        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            return await this.ServiceProduct.FindByName(name);
        }

        public override async Task<int> Add(Product entity)
        {
            this.Validate(entity);
            return await base.Add(entity);
        }

        private void Validate(Product product)
        {
            if(product == null)
                throw new Exception("Informe o produto.");
            if (string.IsNullOrEmpty(product.Name))
                throw new Exception("Informe o nome do produto.");
            if (string.IsNullOrEmpty(product.Description))
                throw new Exception("Informe a descrição do produto.");
            if (product.Image == null)
                throw new Exception("Informe a imagem do produto.");
        }
    }
}
