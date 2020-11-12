namespace ClothingStore.Server.Features.Colors
{
    using Data;
    using Data.Models;
    using Features.Colors.Models;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using ClothingStore.Server.Infrastructure.Services;
    using ClothingStore.Server.Features.Products.Models;

    public class ColorsService : IColorsService
    {
        private readonly ClothingStoreDbContext context;

        public ColorsService(ClothingStoreDbContext context) => this.context = context;

        public async Task<IEnumerable<ColorListingServiceModel>> GetAllColors()
            => await this.context
                .Colors
                .Select(c => new ColorListingServiceModel
                {
                    ColorId = c.Id,
                    Name = c.Name,
                    HexCode = c.HexCode
                })
                .ToListAsync();

        public async Task<ColorDetailsServiceModel> GetColorById(int colorId)
            => await this.context
                .Colors
                .Where(c => c.Id == colorId)
                .Select(c => new ColorDetailsServiceModel
                {
                    Name = c.Name,
                    HexCode = c.HexCode,
                    Products = c.ProductColors
                        .Where(pc => pc.ColorId == colorId)
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

        public async Task<int> CreateColor(string name, string hexCode)
        {
            var color = new Color()
            {
                Name = name,
                HexCode = hexCode,
            };

            await this.context.Colors.AddAsync(color);

            await this.context.SaveChangesAsync();

            return color.Id;
        }

        public async Task<Result> UpdateColor(int colorId, string name, string hexCode)
        {
            var color = await this.GetById(colorId);

            if (color == null)
            {
                return "This color doesn't exist!";
            }

            color.Name = name;
            color.HexCode = hexCode;

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteColor(int colorId)
        {
            var color = await this.GetById(colorId);

            if (color == null)
            {
                return "This color doesn't exist!";
            }

            this.context.Colors.Remove(color);

            await this.context.SaveChangesAsync();

            return true;
        }

        private async Task<Color> GetById(int id)
            => await this.context
                .Colors
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
