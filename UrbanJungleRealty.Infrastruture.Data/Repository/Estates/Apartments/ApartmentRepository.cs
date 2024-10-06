using Microsoft.EntityFrameworkCore;
using UrbanJungleRealty.Application.Interfaces.Estates.Apartments;
using UrbanJungleRealty.Domain.Model.Estates;
using UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;
using UrbanJungleRealty.Infrastruture.Data.Repository.Generics;

namespace UrbanJungleRealty.Infrastruture.Data.Repository.Estates.Apartments
{
    public class ApartmentRepository : Repository<Apartment, Guid>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Apartment?> GetApartmentByLocation(Guid apartmentId, CancellationToken ct)
        {
            return await DbSet.Include(apt => apt.Location).FirstOrDefaultAsync(apt => apt.Id == apartmentId, ct);
        }
    }
}

