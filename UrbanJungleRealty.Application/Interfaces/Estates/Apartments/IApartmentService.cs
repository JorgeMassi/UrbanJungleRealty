using UrbanJungleRealty.Application.Dtos.Estates.Apartments;
using UrbanJungleRealty.Application.Interfaces.Generics;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Interfaces.Estates.Apartments
{
    public interface IApartmentService : IService<Apartment, Guid>
    {
        Task<IEnumerable<ApartmentResponseDto>> GetAll();
        Task<ApartmentResponseDto> GetById(Guid id);
        Task<ApartmentResponseDto> Create(ApartmentRequestDto apartment);
        Task<ApartmentResponseDto> Update(ApartmentRequestDto apartment);
        Task<ApartmentResponseDto> Delete(ApartmentDeleteRequestDto apartment);
        Task<ApartmentResponseDto> Delete(Guid id);
    }
}
