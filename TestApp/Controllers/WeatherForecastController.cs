using Microsoft.AspNetCore.Mvc;
using TestApp.Services;

namespace TestApp.Controllers
{
    [ApiController]
     [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastService _service;
        public static readonly dynamic[] _summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            WeatherForecastService service
        )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(int days)
        {
            return StatusCode(201, _service.get(days));
        }

        [HttpGet("week")]

        public ActionResult Get()
        {
            return StatusCode(201, _service.get(7));
        }
        [HttpGet("month")]

        public IEnumerable<WeatherForecast> GetMonth()
        {
            return _service.get(31);
        }
    }
}