using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomLogAdvance.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            _logger.LogInformation("Enter get api");
            GlobalDiagnosticsContext.Set("Author", "Akash");
            throw new Exception("Force global error");
            _logger.LogInformation("Write author");
            try
            {
                _logger.LogInformation("Fetching weather data");
                throw new Exception("Get data failed");
                return weatherForecasts;
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return weatherForecasts;
            }
        }
    }
}
