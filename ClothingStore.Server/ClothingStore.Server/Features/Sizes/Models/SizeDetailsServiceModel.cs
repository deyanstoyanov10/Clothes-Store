namespace ClothingStore.Server.Features.Sizes.Models
{
    using Features.Products.Models;

    using System.Collections.Generic;

    public class SizeDetailsServiceModel : BaseSizeServiceModel
    {
        public List<ProductsListingServiceModel> Products { get; set; }
    }
}
