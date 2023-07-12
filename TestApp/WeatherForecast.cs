using TestApp.Enums;
using TestApp.Utils.WeatherForecast;

namespace TestApp
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary => WeatherForecastUtils.getSummaryFromTemperature(this.TemperatureC).ToString();
    }
}