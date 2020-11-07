namespace ClothingStore.Server.Features.Category
{
    using Features.Category.Models;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Infrastructure.Services;
    using static Infrastructure.WebConstants;
    using Microsoft.AspNetCore.Authorization;

    [AllowAnonymous]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categories;

        public CategoryController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryListingServiceModel>> All()
            => await this.categories.GetAll();

        [HttpGet]
        [Route(Id)]
        public async Task<CategoryListingServiceModel> Details(int id)
            => await this.categories.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                Result result = "Model is not valid.";
                return BadRequest(result.Error);
            }

            await this.categories.Create(model.Type, model.Name);

            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id, CategoryUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                Result res = "Model is not valid.";
                return BadRequest(res.Error);
            }

            var result = await this.categories.Update(id, model.Type, model.Name);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.categories.Delete(id);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
