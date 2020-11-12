namespace ClothingStore.Server.Features.Colors
{
    using Features.Colors.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.WebConstants;

    public class ColorsController : ApiController
    {
        private readonly IColorsService colors;

        public ColorsController(IColorsService colors) => this.colors = colors;

        [HttpGet]
        public async Task<IEnumerable<ColorListingServiceModel>> All()
            => await this.colors.GetAllColors();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ColorDetailsServiceModel>> ColorDetails(int id)
            => await this.colors.GetColorById(id);

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateColorRequestModel model)
        {
            int id = await this.colors.CreateColor(model.Name, model.HexCode);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id,[FromBody] UpdateColorRequestModel model)
        {
            var result = await this.colors.UpdateColor(id, model.Name, model.HexCode);

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
            var result = await this.colors.DeleteColor(id);

            if (result.Failure)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
