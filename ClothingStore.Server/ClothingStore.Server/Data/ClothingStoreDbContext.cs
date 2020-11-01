namespace ClothingStore.Server.Data
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ClothingStoreDbContext : IdentityDbContext<AppUser>
    {
        public ClothingStoreDbContext(DbContextOptions<ClothingStoreDbContext> options)
            : base(options)
        {
        }
    }
}
