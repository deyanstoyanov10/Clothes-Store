namespace ClothingStore.Server.Features.Identity
{
    using ClothingStore.Server.Models;
    using ClothingStore.Server.Features.Identity.Models;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    public class AuthController : ApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IAuthService auth;
        private readonly AppSettings appSettings;

        public AuthController(
            UserManager<AppUser> userManager,
            IAuthService auth,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.auth = auth;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.auth.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}
