namespace ClothingStore.Server.Data.Configurations
{
    using ClothingStore.Server.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductSizeConfig : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder
                .HasKey(x => new { x.ProductId, x.SizeId });

            builder
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductSizes)
                .HasForeignKey(p => p.ProductId);

            builder
                .HasOne(c => c.Size)
                .WithMany(pc => pc.ProductSizes)
                .HasForeignKey(c => c.SizeId);
        }
    }
}
