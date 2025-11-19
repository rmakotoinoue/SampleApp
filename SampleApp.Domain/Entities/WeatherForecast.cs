namespace SampleApp.Domain.Entities
{
    public class WeatherForecast    
    {
        public int Id { get; set; }  // PK obrigatória
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
