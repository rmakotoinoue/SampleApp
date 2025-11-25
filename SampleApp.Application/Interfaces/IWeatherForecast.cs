namespace SampleApp.Application.Interfaces
{
    public interface IWeatherForecast
    {
        Task<SampleApp.Domain.Entities.WeatherForecast?> GetByDateAsync(DateOnly date);
        Task<SampleApp.Domain.Entities.WeatherForecast[]> GetAllAsync();
        Task<SampleApp.Domain.Entities.WeatherForecast> CreateAsync(SampleApp.Domain.Entities.WeatherForecast weatherForecast, CancellationToken cancellationToken);
        SampleApp.Domain.Entities.WeatherForecast[] GetAll();
    }
}
