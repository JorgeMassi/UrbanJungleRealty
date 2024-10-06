using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanJungleRealty.Domain.Model.Profile
{
    public record DataProtectionKeys(byte[] PasswordHash, byte[] PasswordSalt);
}
