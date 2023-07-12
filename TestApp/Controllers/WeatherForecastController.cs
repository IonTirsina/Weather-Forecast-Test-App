using Microsoft.AspNetCore.Mvc;
using TestApp.Enums;
using TestApp.Services;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;

        public static readonly string[] _summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        public WeatherForecastController(
            WeatherForecastService weatherForecastService
        )
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("{period}")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForPeriod(WeatherForecastPeriod period)
        {
            var periodInDays = (int)period;

            var weatherForecast = _weatherForecastService.get(periodInDays);

            return Ok(weatherForecast);
        }

        [HttpGet("{days:int}")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForDays(int days)
        {
            var weatherForecast = _weatherForecastService.get(days);

            return Ok(weatherForecast);
        }
    }
}