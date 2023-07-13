using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestApp.Domain.WeatherForecast;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(
            IWeatherForecastService weatherForecastService
        )
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("period/{period}")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForPeriod(WeatherForecastPeriod period)
        {
            var periodInDays = (int)period;

            var weatherForecast = _weatherForecastService.GetForDays(periodInDays);

            return Ok(weatherForecast);
        }

        [HttpGet("period/days/{days}")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForDays(int days)
        {
            try
            {
                var weatherForecast = _weatherForecastService.GetForDays(days);

                return Ok(weatherForecast);
            } catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("period/range")]
        public ActionResult<IEnumerable<WeatherForecast>> GetForDateRange([FromQuery][Required] DateTime fromDate, [FromQuery][Required] DateTime toDate)
        {
            try
            {
                var weatherForecast = _weatherForecastService.GetForDateRange(fromDate, toDate);

                return Ok(weatherForecast);
            } catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}