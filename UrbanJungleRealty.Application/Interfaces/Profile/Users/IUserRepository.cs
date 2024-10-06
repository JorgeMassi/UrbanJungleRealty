using UrbanJungleRealty.Application.Interfaces.Generics;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Interfaces.Profile.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public Task<User> GetByUsername(string username);
    }
}
