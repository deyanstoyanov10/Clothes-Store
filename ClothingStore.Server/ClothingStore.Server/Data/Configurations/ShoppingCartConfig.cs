
namespace ClothingStore.Server.Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasMany(sci => sci.ShoppingCartItems)
                .WithOne(sc => sc.ShoppingCart)
                .HasForeignKey(sc => sc.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
