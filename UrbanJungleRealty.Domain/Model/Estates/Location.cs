using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanJungleRealty.Domain.Model.Estates
{
    [Table("Localizations")]
    public class Location
    {
        [Key]
        [Column("Location")]
        public int Id { get; set; }
        public string? Street { get; set; } = string.Empty;
        public string? City { get; set; } = "Lisboa";
        public string? Country { get; set; } = "Portugal";
        public string? ZipCode { get; set; }
        public List<Apartment>? Apartments { get; set; }
    }
}
