namespace ClothingStore.Server.Features.Sizes
{
    using ClothingStore.Server.Data;
    using ClothingStore.Server.Data.Models;
    using ClothingStore.Server.Features.Products.Models;
    using ClothingStore.Server.Features.Sizes.Models;
    using ClothingStore.Server.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SizesService : ISizesService
    {
        private readonly ClothingStoreDbContext context;

        public SizesService(ClothingStoreDbContext context) => this.context = context;

        public async Task<IEnumerable<SizeListingServiceModel>> GetAll()
            => await this.context
                .Sizes
                .Select(s => new SizeListingServiceModel
                {
                    SizeId = s.Id,
                    Name = s.Name
                })
                .ToListAsync();

        public async Task<SizeDetailsServiceModel> GetSizeById(int sizeId)
            => await this.context
                .Sizes
                .Where(s => s.Id == sizeId)
                .Select(s => new SizeDetailsServiceModel
                {
                    Name = s.Name,
                    Products = s.ProductSizes
                        .Where(s => s.SizeId == sizeId)
                        .Select(p => new ProductsListingServiceModel
                        {
                            Id = p.Product.Id,
                            Title = p.Product.Title,
                            Price = p.Product.Price,
                            MainPicture = p.Product.Pictures.FirstOrDefault()
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateSize(string name)
        {
            var size = new Size()
            {
                Name = name
            };

            await this.context.AddAsync(size);

            await this.context.SaveChangesAsync();

            return size.Id;
        }

        public async Task<Result> UpdateSize(int sizeId, string name)
        {
            var size = await this.GetById(sizeId);

            if (size == null)
            {
                return "This size doesn't exist!";
            }

            size.Name = name;

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteSize(int sizeId)
        {
            var size = await this.GetById(sizeId);

            if (size == null)
            {
                return "This size doesn't exist!";
            }

            this.context.Sizes.Remove(size);

            await this.context.SaveChangesAsync();

            return true;
        }

        private async Task<Size> GetById(int id)
            => await this.context
                .Sizes
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
