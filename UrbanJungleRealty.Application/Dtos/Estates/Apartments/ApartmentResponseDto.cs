using UrbanJungleRealty.Application.Dtos.Estates.Locations;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Dtos.Estates.Apartments
{
    public class ApartmentResponseDto
    {
        public ApartmentResponseDto() { }

        public ApartmentResponseDto(Apartment apartment)
        {
            Id = apartment.Id;
            Price = apartment.Price;
            Image = apartment.Image;
            Description = apartment.Description;
            Location = new LocationResponseDto(apartment.Location);
        }

        public Guid? Id { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public LocationResponseDto? Location { get; set; }



    }
}
