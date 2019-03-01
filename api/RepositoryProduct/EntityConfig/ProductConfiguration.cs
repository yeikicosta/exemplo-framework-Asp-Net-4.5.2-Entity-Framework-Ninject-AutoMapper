using DomainProduct;
using System.Data.Entity.ModelConfiguration;
namespace RepositoryProduct.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(200);
            Property(p => p.Price).IsRequired();
            Property(p => p.Image).IsRequired().IsMaxLength();
            Property(p => p.Description).IsRequired().HasMaxLength(500);
        }
    }
}
