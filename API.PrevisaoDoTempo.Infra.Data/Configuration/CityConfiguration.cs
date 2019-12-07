using API.PrevisaoDoTempo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.PrevisaoDoTempo.Infra.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(_ => _.CustomCode)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(_ => _.Country)
                .HasMaxLength(3);

            builder.HasIndex(_ => _.CustomCode).IsUnique();
        }
    }
}
