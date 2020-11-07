namespace ClothingStore.Server.Data.Configurations
{
    using ClothingStore.Server.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Infrastructure.EntityConfigConstants;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryNameMaxLength);

            builder
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
