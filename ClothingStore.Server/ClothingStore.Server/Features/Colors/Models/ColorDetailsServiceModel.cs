namespace ClothingStore.Server.Features.Colors.Models
{
    using Features.Products.Models;

    using System.Collections.Generic;

    public class ColorDetailsServiceModel : BaseColorServiceModel
    {
        public List<ProductsListingServiceModel> Products { get; set; }
    }
}
