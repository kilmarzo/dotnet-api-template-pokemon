using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_template.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly Dictionary<string, string> Summaries = new Dictionary<string, string>()
{
    {"Freezing", "Better stay inside, it's freezing!"},
    {"Bracing", "Brace yourself, it's quite cold!"},
    {"Chilly", "It's chilly, don't forget your coat."},
    {"Cool", "It's cool, you might need a light sweater."},
    {"Mild", "It's mild, dress normally."},
    {"Warm", "It's warm, enjoy the nice weather!"},
    {"Balmy", "It's balmy, feel the breeze."},
    {"Hot", "It's hot, stay hydrated."},
    {"Sweltering", "It's sweltering, better find some shade."},
    {"Scorching", "It's scorching, make sure to wear sunscreen."},
};


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index =>
        {
            var summaryKey = Summaries.Keys.ElementAt(Random.Shared.Next(Summaries.Count));
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaryKey,
                Advice = Summaries[summaryKey]
            };
        })
        .ToArray();
    }


    [HttpGet("{daysAhead:int}", Name = "GetSpecificDayWeatherForecast")]
    public WeatherForecast Get(int daysAhead)
    {
        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAhead)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

}
