using Microsoft.EntityFrameworkCore;
using Moq;
using SampleApp.ApiService.Contexts;
using SampleApp.Domain.Entities;
using SampleApp.Infrastructure.Repositories;

public class RepositoryUnitTests
{
    [Fact]
    public async Task GetAll_WhenCalled_ReturnsForecastsAsync()
    {
        // Arrange
        var data = new List<WeatherForecast>
        {
            new WeatherForecast { TemperatureC = 20, Summary = "Rainy" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<WeatherForecast>>();
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<AppDbContext>();
        mockContext.Setup(c => c.WeatherForecasts).Returns(mockSet.Object);
        var repository = new WeatherForecastRepository(mockContext.Object);

        // Act
        var result = repository.GetAll();

        // Assert
        Assert.Single(result);
        Assert.Equal("Rainy", result.First().Summary);
    }
}