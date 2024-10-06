using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Interfaces.Profile.Token
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
