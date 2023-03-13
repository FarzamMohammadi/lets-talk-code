using Ltc.API.Application;
using Ltc.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ltc.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(
                             index => new WeatherForecast
                             {
                                 Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                 TemperatureC = Random.Shared.Next(-20, 55),
                                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                             }
                         )
                         .ToArray();
    }
}