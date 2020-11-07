namespace ClothingStore.Server.Data
{
    using ClothingStore.Server.Models;
    using ClothingStore.Server.Data.Models;
    using ClothingStore.Server.Data.Configurations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ClothingStoreDbContext : IdentityDbContext<AppUser>
    {
        public ClothingStoreDbContext(DbContextOptions<ClothingStoreDbContext> options)
            : base(options) {}

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new SizeConfig());
            builder.ApplyConfiguration(new ColorConfig());
            builder.ApplyConfiguration(new PictureConfig());
            builder.ApplyConfiguration(new ShoppingCartConfig());
            builder.ApplyConfiguration(new ShoppingCartItemConfig());
            base.OnModelCreating(builder);
        }
    }
}
