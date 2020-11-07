namespace ClothingStore.Server.Features.Category.Models
{
    using Data.Enums;

    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryRequestModel
    {
        [Required]
        public Type Type { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
