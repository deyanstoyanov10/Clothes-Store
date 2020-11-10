namespace ClothingStore.Server.Features.Categories
{
    using Data.Enums;
    using Features.Categories.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ClothingStore.Server.Infrastructure.Services;

    public interface ICategoriesService
    {
        Task<IEnumerable<CategoriesListingServiceModel>> GetAll();

        Task<CategoriesListingServiceModel> Details(int id);

        Task<int> Create(Type type, string name);

        Task<Result> Update(int categoryId, Type type, string name);

        Task<Result> Delete(int categoryId);
    }
}
