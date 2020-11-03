namespace ClothingStore.Server.Features.Identity
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId, string username, string secret);
    }
}
