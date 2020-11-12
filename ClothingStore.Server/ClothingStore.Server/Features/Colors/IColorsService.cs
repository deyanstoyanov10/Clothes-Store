namespace ClothingStore.Server.Features.Colors
{
    using Features.Colors.Models;
    using Infrastructure.Services;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IColorsService
    {
        Task<IEnumerable<ColorListingServiceModel>> GetAllColors();

        Task<ColorDetailsServiceModel> GetColorById(int colorId);

        Task<int> CreateColor(string name, string hexCode);

        Task<Result> UpdateColor(int colorId, string name, string hexCode);

        Task<Result> DeleteColor(int colorId);
    }
}
