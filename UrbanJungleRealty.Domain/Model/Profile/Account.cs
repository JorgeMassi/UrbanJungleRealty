using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanJungleRealty.Domain.Model.Profile
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSaltHash { get; set; }
    }
}
