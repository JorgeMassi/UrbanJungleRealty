using UrbanJungleRealty.Application.Interfaces.Generics;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Interfaces.Estates.Apartments
{
    public interface IApartmentRepository : IRepository<Apartment, Guid>
    {
        public Task<Apartment> GetApartmentByLocation(Guid apartmentId, CancellationToken cancellationToken);
    }
}
