namespace ClothingStore.Server.Features.Sizes.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.EntityConfigConstants;
    public class BaseSizeRequestModel
    {
        [Required]
        [MaxLength(SizeNameMaxLength)]
        public string Name { get; set; }
    }
}
