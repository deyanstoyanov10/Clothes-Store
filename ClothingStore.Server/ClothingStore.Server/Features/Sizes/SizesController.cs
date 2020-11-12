namespace ClothingStore.Server.Features.Sizes
{
    using Features.Sizes.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    
    using static Infrastructure.WebConstants;

    public class SizesController : ApiController
    {
        private readonly ISizesService sizes;

        public SizesController(ISizesService sizes)
        {
            this.sizes = sizes;
        }

        [HttpGet]
        public async Task<IEnumerable<SizeListingServiceModel>> All()
            => await this.sizes.GetAll();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<SizeDetailsServiceModel>> SizeDetails(int id)
            => await this.sizes.GetSizeById(id);

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSizeRequestModel model)
        {
            var id = await this.sizes.CreateSize(model.Name);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id,[FromBody] UpdateSizeRequestModel model)
        {
            var result = await this.sizes.UpdateSize(id, model.Name);

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
            var result = await this.sizes.DeleteSize(id);

            if (result.Failure)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
