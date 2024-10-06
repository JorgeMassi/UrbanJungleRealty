using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanJungleRealty.Domain.Model.Estates;

namespace UrbanJungleRealty.Infrastruture.Data.Configurations
{
    internal class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartamentoz");
            builder.HasOne(apt => apt.Location).WithMany(loc => loc.Apartments);
        }
    }
}
