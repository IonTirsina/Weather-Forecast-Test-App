using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

            var weatherForecast = _weatherForecastService.getForDays(periodInDays);

            return Ok(weatherForecast);
        }

        [HttpGet("{days:int}")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForDays(int days)
        {
            try
            {
                var weatherForecast = _weatherForecastService.getForDays(days);

                return Ok(weatherForecast);
            } catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetForDateRange([FromQuery][Required] DateTime fromDate, [FromQuery][Required] DateTime toDate)
        {
            try
            {
                var weatherForecast = _weatherForecastService.getForDateRange(fromDate, toDate);

                return Ok(weatherForecast);
            } catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}