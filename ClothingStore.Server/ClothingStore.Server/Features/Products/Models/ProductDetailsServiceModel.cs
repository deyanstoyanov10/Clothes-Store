namespace ClothingStore.Server.Features.Products.Models
{
    using Features.Sizes.Models;
    using Features.Colors.Models;

    using System.Collections.Generic;

    public class ProductDetailsServiceModel : BaseProductModel
    {
        public string Description { get; set; }

        public uint Quantity { get; set; }

        public bool Status { get; set; }

        public string SupplierUrl { get; set; }

        public int CategoryId { get; set; }

        public List<ColorListingServiceModel> Colors { get; set; }

        public List<SizeListingServiceModel> Sizes { get; set; }

        public List<PictureServiceModel> Pictures { get; set; }
    }
}
