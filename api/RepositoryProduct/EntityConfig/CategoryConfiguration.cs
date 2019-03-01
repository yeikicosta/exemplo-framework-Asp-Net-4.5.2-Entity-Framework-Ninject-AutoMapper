using DomainProduct;
using System.Data.Entity.ModelConfiguration;

namespace RepositoryProduct.EntityConfig
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Name).IsRequired().HasMaxLength(200);
        }
    }
}
