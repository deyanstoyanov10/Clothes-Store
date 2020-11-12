namespace ClothingStore.Server.Features.Colors.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.EntityConfigConstants;

    public abstract class BaseColorRequestModel
    {
        [Required]
        [MaxLength(ColorNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ColorHexMaxLength)]
        public string HexCode { get; set; }
    }
}
