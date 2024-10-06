using System.Security.Cryptography;
using System.Text;
using UrbanJungleRealty.Application.Interfaces.Profile.DataProtection;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Services.Profile
{
    public class DataProtectionService : IDataProtectionService
    {
        public DataProtectionKeys Protect(string password)
        {
            using var hmac = new HMACSHA512();

            byte[] hashedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] saltKey = hmac.Key;

            return new DataProtectionKeys(hashedPass, saltKey);
        }

        public byte[] GetComputedHash(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash;
        }
    }
}
