using Microsoft.EntityFrameworkCore;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;
using UrbanJungleRealty.Domain.Model.Profile;
using UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;
using UrbanJungleRealty.Infrastruture.Data.Repository.Generics;

namespace UrbanJungleRealty.Infrastruture.Data.Repository.Profile.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsername(string username)
        {
            return DbSet
                .Include(x => x.Account)
                .FirstOrDefault(x => x.Account.Username == username);
        }
    }
}
