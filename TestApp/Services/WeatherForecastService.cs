namespace TestApp.Services
{
    public class WeatherForecastService
    {
        public IEnumerable<WeatherForecast> get(int days)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Controllers.WeatherForecastController._summaries[Random.Shared.Next(Controllers.WeatherForecastController._summaries.Length)]
            });
        }
    }
}
