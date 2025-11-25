using Mediator.Abstractions;

namespace SampleApp.Application.WeatherForecast.UserCases.Create
{
    public class Request: IRequest<int>
    {
        public int TemperatureC { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
