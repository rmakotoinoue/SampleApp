using Mediator.Abstractions;
using Mediator.Extensions;
using Microsoft.EntityFrameworkCore;
using SampleApp.ApiService.Contexts;
using SampleApp.ApiService.Endpoints;
using SampleApp.Application.Interfaces;
using SampleApp.Application.WeatherForecast.UserCases.Create;
using SampleApp.Infrastructure.Repositories;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add context SQLite
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));

        // Add service defaults & Aspire client integrations.
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddProblemDetails();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        //Add controllers if needed in future
        builder.Services.AddControllers();

        builder.Services.AddTransient<IWeatherForecast, WeatherForecastRepository>();
        builder.Services.AddScoped<IHandler<Request, int>, Handler>();
        builder.Services.AddMediator(typeof(Program).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.MapDefaultEndpoints();
        app.MapForecastEndpoints();

        // Seed de dados mockados
        /*
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (!db.WeatherForecasts.Any())
            {
                db.WeatherForecasts.AddRange(
                    new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 20, Summary = "Chuvoso" },
                    new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 25, Summary = "Ensolarado" },
                    new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 18, Summary = "Nublado" }
                );
                db.SaveChanges();
            }
        }*/
        app.Run();
    }
}