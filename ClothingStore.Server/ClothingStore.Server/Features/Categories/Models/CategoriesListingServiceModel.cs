namespace ClothingStore.Server.Features.Categories.Models
{
    using ClothingStore.Server.Data.Enums;

    public class CategoriesListingServiceModel
    {
        public int CategoryId { get; set; }

        public Type Type { get; set; }

        public string TypeName { get; set; }

        public string Name { get; set; }
    }
}
