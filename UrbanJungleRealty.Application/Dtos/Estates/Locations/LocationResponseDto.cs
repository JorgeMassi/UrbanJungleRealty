using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Application.Dtos.Estates.Locations
{
    public class LocationResponseDto
    {
        public int? Id { get; set; }
        public string? City { get; set; }

        public LocationResponseDto() { }

        public LocationResponseDto(Location location)
        {
            if (location == null)
            {
                
                Id = 0;
                City = "TBA..."; 
            }
            else
            {
                Id = location.Id;
                City = location.City;
            }

        }
    }
}
