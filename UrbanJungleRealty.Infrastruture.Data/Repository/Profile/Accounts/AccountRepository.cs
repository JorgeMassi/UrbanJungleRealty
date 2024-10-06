using UrbanJungleRealty.Application.Interfaces.Profile.Accounts;
using UrbanJungleRealty.Domain.Model.Profile;
using UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;
using UrbanJungleRealty.Infrastruture.Data.Repository.Generics;

namespace UrbanJungleRealty.Infrastruture.Data.Repository.Profile.Accounts
{
    public class AccountRepository : Repository<Account, Guid>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
