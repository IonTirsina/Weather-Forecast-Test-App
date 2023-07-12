using TestApp.Utils.WeatherForecast;

namespace TestApp
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => WeatherForecastUtils.convertCelsiusToFarenheit(this.TemperatureC);

        public string Summary => WeatherForecastUtils.getSummaryFromTemperature(this.TemperatureC).ToString();
    }
}