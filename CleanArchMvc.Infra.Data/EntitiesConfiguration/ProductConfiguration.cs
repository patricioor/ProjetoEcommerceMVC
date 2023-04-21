using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Configurações da entidade
            //PK
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);
            
            // Configurando a categoria para muitos produtos. Category Id é a FK
            builder.HasOne(e => e.Category).WithMany(e =>e.Products).HasForeignKey(e => e.CategoryId);
        }
    }
}
