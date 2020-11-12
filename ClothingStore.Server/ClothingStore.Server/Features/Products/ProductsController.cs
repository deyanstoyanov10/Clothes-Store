namespace ClothingStore.Server.Features.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ClothingStore.Server.Features.Products.Models;
    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.WebConstants;

    public class ProductsController : ApiController
    {
        private readonly IProductsService products;

        public ProductsController(IProductsService products)
        {
            this.products = products;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductsListingServiceModel>> All()
            => await this.products.GetAllProducts();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ProductDetailsServiceModel>> ProductDetails(int id)
            => await this.products.GetProductById(id);
    }
}
