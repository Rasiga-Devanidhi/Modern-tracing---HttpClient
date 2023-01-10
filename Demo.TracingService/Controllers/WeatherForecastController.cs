using Microsoft.AspNetCore.Mvc;

namespace Demo.TracingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogWarning(4002, "TRACING DEMO: Back end service weather forecast requested");
            return Enumerable.Range(1, 2).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = 30,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Name = "Rasiga",
                //TemperatureC = TemperatureC+10
            })
            .ToArray();
        }
    }
}