namespace ClothingStore.Server.Features.Category.Models
{
    using ClothingStore.Server.Data.Enums;

    public class CategoryListingServiceModel
    {
        public int CategoryId { get; set; }

        public Type Type { get; set; }

        public string TypeName { get; set; }

        public string Name { get; set; }
    }
}
