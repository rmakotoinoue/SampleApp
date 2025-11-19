namespace SampleApp.Application.Dtos
{
    public record WeatherForecastResponse(DateOnly date, int temperatureC, string? summary);
}
