using Microsoft.AspNetCore.Mvc;
using TestApp.Services;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;

        public static readonly dynamic[] _summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        public WeatherForecastController(
            WeatherForecastService weatherForecastService
        )
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(int days)
        {
            return StatusCode(201, _weatherForecastService.get(days));
        }

        [HttpGet("week")]

        public ActionResult Get()
        {
            return StatusCode(201, _weatherForecastService.get(7));
        }
        [HttpGet("month")]

        public IEnumerable<WeatherForecast> GetMonth()
        {
            return _weatherForecastService.get(31);
        }
    }
}