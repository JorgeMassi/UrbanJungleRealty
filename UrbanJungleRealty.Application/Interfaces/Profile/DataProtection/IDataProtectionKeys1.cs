using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Interfaces.Profile.DataProtection
{
    public interface IDataProtectionService
    {
        DataProtectionKeys Protect(string password);
        byte[] GetComputedHash(string password, byte[] salt);
    }
}
