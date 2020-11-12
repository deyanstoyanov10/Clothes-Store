namespace ClothingStore.Server.Features.Sizes
{
    using Features.Sizes.Models;
    using Infrastructure.Services;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface ISizesService
    {
        Task<IEnumerable<SizeListingServiceModel>> GetAll();

        Task<SizeDetailsServiceModel> GetSizeById(int sizeId);

        Task<int> CreateSize(string name);

        Task<Result> UpdateSize(int sizeId, string name);

        Task<Result> DeleteSize(int sizeId);
    }
}
