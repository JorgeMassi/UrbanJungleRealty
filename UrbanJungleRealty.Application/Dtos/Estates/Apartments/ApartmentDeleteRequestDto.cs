using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanJungleRealty.Application.Dtos.Estates.Apartments
{
    public class ApartmentDeleteRequestDto
    {
        public Guid Id { get; set; }
        public ApartmentDeleteRequestDto(Guid Id){ this.Id = Id; }
    }
}
