namespace ClothingStore.Server.Features.Category
{
    using Data.Enums;
    using Features.Category.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ClothingStore.Server.Infrastructure.Services;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListingServiceModel>> GetAll();

        Task<CategoryListingServiceModel> Details(int id);

        Task Create(Type type, string name);

        Task<Result> Update(int categoryId, Type type, string name);

        Task<Result> Delete(int categoryId);
    }
}
