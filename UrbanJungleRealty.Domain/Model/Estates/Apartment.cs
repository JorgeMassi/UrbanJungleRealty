using System.Diagnostics;
using System.Net;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Domain.Model.Estates
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public Typology? Type { get; set; }
        public Location? Location { get; set; }
        public int YearBuilt { get; set; }
        public double TotalArea { get; set; }
        public int Rooms { get; set; }
        public int Floors { get; set; }
        public int Bathrooms { get; set; }
        public bool Garage { get; set; }
        public enum Condition { New, Used, Renovated }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public User? User { get; set; }
        public Value? Price { get; set; }

    }
}
