using TestApp.Utils.WeatherForecast;

namespace TestApp.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => WeatherForecastUtils.convertCelsiusToFarenheit(TemperatureC);

        public string Summary => WeatherForecastUtils.getSummaryFromTemperature(TemperatureC).ToString();
    }
}