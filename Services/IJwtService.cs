using RealEstate.Api.Data.Entities;

namespace RealEstate.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}