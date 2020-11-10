namespace ClothingStore.Server.Features.Categories
{
    using Features.Categories.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using static Infrastructure.WebConstants;

    [AllowAnonymous]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriesListingServiceModel>> All()
            => await this.categories.GetAll();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CategoriesListingServiceModel>> Details(int id)
            => await this.categories.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoriesRequestModel model)
        {
            var id = await this.categories.Create(model.Type, model.Name);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id,[FromBody] CategoriesUpdateRequestModel model)
        {
            var result = await this.categories.Update(id, model.Type, model.Name);

            if (result.Failure)
            {
                return BadRequest(result);
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
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
