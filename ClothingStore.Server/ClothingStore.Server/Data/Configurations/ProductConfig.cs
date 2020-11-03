namespace ClothingStore.Server.Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Infrastructure.EntityConfigConstants;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(ProductTitleMaxLength);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(ProductDescriptionMaxLength);

            builder
                .Property(p => p.Status)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(p => p.SupplierUrl)
                .HasMaxLength(ProductSupplierUrlMaxLength);

            builder
                .HasOne(sci => sci.ShoppingCartItem)
                .WithOne(p => p.Product)
                .HasForeignKey<ShoppingCartItem>(p => p.ProductId);

            builder
                .HasMany(s => s.Sizes)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Colors)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.Pictures)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
