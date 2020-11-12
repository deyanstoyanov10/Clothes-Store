namespace ClothingStore.Server.Features.Products
{
    using Data;
    using Features.Products.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using ClothingStore.Server.Features.Sizes.Models;

    public class ProductsService : IProductsService
    {
        private readonly ClothingStoreDbContext context;

        public ProductsService(ClothingStoreDbContext context) => this.context = context;

        public async Task<IEnumerable<ProductsListingServiceModel>> GetAllProducts()
            => await this.context
                .Products
                .Select(p => new ProductsListingServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    MainPicture = p.Pictures.FirstOrDefault()
                })
                .ToListAsync();

        public async Task<ProductDetailsServiceModel> GetProductById(int productId)
            => await this.context
                .Products
                .Select(p => new ProductDetailsServiceModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Status = p.Status,
                    SupplierUrl = p.SupplierUrl,
                    CategoryId = p.CategoryId,
                    MainPicture = p.Pictures.FirstOrDefault(),
                    Pictures = p.Pictures
                        .Select(picture => new Colors.Models.PictureServiceModel
                        {
                            PicturePath = picture.PicturePath
                        })
                        .ToList(),
                    Colors = p.ProductColors
                        .Where(p => p.ProductId == productId)
                        .Select(c => new Colors.Models.ColorListingServiceModel
                        {
                            ColorId = c.Color.Id,
                            Name = c.Color.Name,
                            HexCode = c.Color.HexCode
                        })
                        .ToList(),
                    Sizes = p.ProductSizes
                        .Where(p => p.ProductId == productId)
                        .Select(c => new SizeListingServiceModel
                        {
                            SizeId = c.Size.Id,
                            Name = c.Size.Name
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync();
    }
}
