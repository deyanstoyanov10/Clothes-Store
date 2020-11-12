namespace ClothingStore.Server.Features.Categories.Models
{
    using Data.Enums;

    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.EntityConfigConstants;

    public abstract class BaseCategoriesRequestModel
    {
        [Required]
        public Type Type { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
