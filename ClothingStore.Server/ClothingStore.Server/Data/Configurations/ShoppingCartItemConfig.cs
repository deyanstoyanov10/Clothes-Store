namespace ClothingStore.Server.Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Infrastructure.EntityConfigConstants;

    public class ShoppingCartItemConfig : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Size)
                .IsRequired()
                .HasMaxLength(SizeNameMaxLength);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(ColorNameMaxLength);

        }
    }
}
