using UrbanJungleRealty.Application.Interfaces.Generics;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Interfaces.Profile.Accounts
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
    }
}
