namespace TestApp.Domain.WeatherForecast
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => WeatherForecastUtils.ConvertCelsiusToFarenheit(TemperatureC);

        public string Summary => WeatherForecastUtils.GetSummaryFromTemperature(TemperatureC).ToString();
    }
}