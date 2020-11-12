namespace ClothingStore.Server.Features.Products.Models
{
    using Data.Models;

    public abstract class BaseProductModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public Picture MainPicture { get; set; }
    }
}
