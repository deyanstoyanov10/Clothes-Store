namespace ClothingStore.Server.Data.Configurations
{
    using ClothingStore.Server.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductColorConfig : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder
                .HasKey(x => new { x.ProductId, x.ColorId });

            builder
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductColors)
                .HasForeignKey(p => p.ProductId);

            builder
                .HasOne(c => c.Color)
                .WithMany(pc => pc.ProductColors)
                .HasForeignKey(c => c.ColorId);
        }
    }
}
