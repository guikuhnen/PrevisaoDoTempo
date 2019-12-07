using API.PrevisaoDoTempo.Domain.Models;
using API.PrevisaoDoTempo.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace API.PrevisaoDoTempo.Infra.Data.Context
{
    public class PrevisaoDoTempoContext : DbContext
    {
        public PrevisaoDoTempoContext(DbContextOptions<PrevisaoDoTempoContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }
    }
}
