namespace ClothingStore.Server.Features.Categories
{
    using ClothingStore.Server.Features.Categories.Models;
    using ClothingStore.Server.Infrastructure.Services;
    using Data;
    using Data.Enums;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesService : ICategoriesService
    {
        private readonly ClothingStoreDbContext context;

        public CategoriesService(ClothingStoreDbContext context) => this.context = context;

        public async Task<IEnumerable<CategoriesListingServiceModel>> GetAll()
            => await this.context
                .Categories
                .Select(c => new CategoriesListingServiceModel
                {
                    CategoryId = c.Id,
                    Type = c.Type,
                    TypeName = c.Type.ToString(),
                    Name = c.Name
                })
                .ToListAsync();

        public async Task<CategoriesListingServiceModel> Details(int id)
            => await this.context
                .Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoriesListingServiceModel
                {
                    CategoryId = c.Id,
                    Type = c.Type,
                    TypeName = c.Type.ToString(),
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

        public async Task<int> Create(Type type, string name)
        {
            var category = new Category
            {
                Type = type,
                Name = name
            };

            await this.context.Categories.AddAsync(category);

            await this.context.SaveChangesAsync();

            return category.Id;
        }

        public async Task<Result> Update(int categoryId, Type type, string name)
        {
            var category = await this.GetById(categoryId);

            if (category == null)
            {
                return "This category doesn't exist!";
            }

            category.Type = type;
            category.Name = name;

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Delete(int categoryId)
        {
            var category = await this.GetById(categoryId);

            if (category == null)
            {
                return "This category doesn't exist!";
            }

            this.context.Categories.Remove(category);

            await this.context.SaveChangesAsync();

            return true;
        }

        private async Task<Category> GetById(int id)
            => await this.context
                .Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
