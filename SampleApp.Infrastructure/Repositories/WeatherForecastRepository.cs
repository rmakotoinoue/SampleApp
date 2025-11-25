using Microsoft.EntityFrameworkCore;
using SampleApp.ApiService.Contexts;
using SampleApp.Application.Interfaces;
using SampleApp.Domain.Entities;

namespace SampleApp.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecast
    {
        private readonly AppDbContext _context;
        public WeatherForecastRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken)
        {
            _context.WeatherForecasts.Add(weatherForecast);
            await _context.SaveChangesAsync();
            return weatherForecast;
        }

        public async Task<WeatherForecast?> GetByDateAsync(DateOnly date)
        {
            return await _context.WeatherForecasts.FirstOrDefaultAsync(u => u.Date == date);
        }
        public async Task<WeatherForecast[]> GetAllAsync()
        {
            return await _context.WeatherForecasts.ToArrayAsync();
        }

        public WeatherForecast[] GetAll()
        {
            return _context.WeatherForecasts.ToArray();
        }
    }
}
