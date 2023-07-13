namespace TestApp.Domain.WeatherForecast
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetForDays(int days);
        public IEnumerable<WeatherForecast> GetForDateRange(DateTime fromDate, DateTime toDate);
    }
}
