using Mediator.Abstractions;
using SampleApp.Application.Interfaces;

namespace SampleApp.Application.WeatherForecast.UserCases.Create
{
    public class Handler(IWeatherForecast weatherForecastRepo) : IHandler<Request, int>
    {
        public async Task<int> HandleAsync(Request request, CancellationToken cancellationToken = default)
        {
            var weatherForecast = new Domain.Entities.WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };
            await weatherForecastRepo.CreateAsync(weatherForecast, cancellationToken);
            return weatherForecast.Id;
        }
    }
}
