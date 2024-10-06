using UrbanJungleRealty.Application.Dtos.Estates.Apartments;
using UrbanJungleRealty.Application.Interfaces.Estates.Apartments;
using UrbanJungleRealty.Application.Interfaces.UnitOfWork;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Services.Estates
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IApartmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApartmentResponseDto> Create(ApartmentRequestDto apartmentDto)
        {
            //AutoMapper
            Apartment apartment = apartmentDto.ToEntity();
            apartment.Id = Guid.NewGuid();

            //Regra de negócio xyz...
            if (apartment.Location.City.StartsWith("Lis"))
            {
                throw new Exception("Não cabe mais ninguem em lisboa...");
            }


            //Assegurar que não é responsabilidade/atenção do desenvolvedor
            var entity = await _repository.Create(apartment);
            await _unitOfWork.Commit();

            return new ApartmentResponseDto(apartment);
        }

        public async Task<ApartmentResponseDto> Delete(ApartmentDeleteRequestDto apartmentDto)
        {
            Apartment apartment = new Apartment();
            apartment.Id = apartmentDto.Id;

            var entity = _repository.Delete(apartment);
            await _unitOfWork.Commit();
            return new ApartmentResponseDto(entity);
        }


        public async Task<ApartmentResponseDto> Delete(Guid id)
        {
            var entity = await _repository.Delete(id);
            await _unitOfWork.Commit();

            return new ApartmentResponseDto(entity);
        }

        public async Task<IEnumerable<ApartmentResponseDto>> GetAll()
        {
            List<ApartmentResponseDto> allApartments = new List<ApartmentResponseDto>();
            List<Apartment> apartments = (List<Apartment>)await _repository.GetAll();
            foreach (var apartment in apartments)
            {
                allApartments.Add(new ApartmentResponseDto(apartment));
            }
            return allApartments;
        }

        public async Task<ApartmentResponseDto> GetById(Guid id)
        {
            Apartment apartment = await _repository.GetById(id);
            //TODO: Automapper
            return new ApartmentResponseDto(apartment);
        }

        public async Task<ApartmentResponseDto> Update(ApartmentRequestDto apartmentDto)
        {
            //TODO: Automapper
            Apartment apartment = new Apartment();

            var entity = _repository.Update(apartment);
            await _unitOfWork.Commit();

            //TODO: Automapper
            return new ApartmentResponseDto(entity);
        }
    }
}
