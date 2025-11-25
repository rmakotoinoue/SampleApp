using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Entities;

namespace SampleApp.ApiService.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() : base() { }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
