namespace ClothingStore.Server.Features.Products
{
    using Features.Products.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IProductsService
    {
        Task<IEnumerable<ProductsListingServiceModel>> GetAllProducts();

        Task<ProductDetailsServiceModel> GetProductById(int productId);
    }
}
