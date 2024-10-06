using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanJungleRealty.Application.Dtos.Estates.Locations;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Dtos.Estates.Apartments
{
    public class ApartmentRequestDto
    {
        public double? Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public LocationRequestDto? Location { get; set; }

        public Apartment ToEntity()
        {
            Apartment apartment = new Apartment
            {
                // Use null-coalescing operator to handle default price
                Price =  Price ?? 0,

                Image = string.IsNullOrEmpty(Image) ? "NoImage.jpg" : Image,

                Description = string.IsNullOrEmpty(Description) ? "No Description ..." : Description,

                
                Location = Location ?? new Location { Id = 0, City = "No location ..." }
            };

            return apartment;
        }

    }
}
