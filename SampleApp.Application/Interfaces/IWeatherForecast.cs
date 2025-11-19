using SampleApp.Domain.Entities;

namespace SampleApp.Application.Interfaces
{
    public interface IWeatherForecast
    {
        Task<WeatherForecast?> GetByDateAsync(DateOnly date);
        Task<WeatherForecast[]> GetAllAsync();
        Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast);
    }
}
