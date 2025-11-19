using SampleApp.Application.Dtos;
using SampleApp.Application.Interfaces;

namespace SampleApp.ApiService.Endpoints
{
    public static class WeatherForecastEndpoints
    {
        public static WebApplication MapForecastEndpoints(this WebApplication app)
        {
            app.MapGet("/", async (DateOnly date, IWeatherForecast repo) =>
            {
                try
                {
                    var forecast = await repo.GetByDateAsync(date);
                    return forecast is null ? Results.NotFound() : Results.Ok(new WeatherForecastResponse(forecast.Date, forecast.TemperatureC, forecast.Summary));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Erro de operação inválida: {ex.Message}");
                    return Results.Problem("Ocorreu um erro ao processar a solicitação.", statusCode: 500);
                }
            });
            app.MapGet("weatherforecast", async (IWeatherForecast repo) =>
            {
                try
                {
                    var forecasts = await repo.GetAllAsync();
                    var response = forecasts.Select(f => new WeatherForecastResponse(f.Date, f.TemperatureC, f.Summary));
                    return Results.Ok(response);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Erro de operação inválida: {ex.Message}");
                    return Results.Problem("Ocorreu um erro ao processar a solicitação.", statusCode: 500);
                }
            });
            return app;
        }
    }
}
