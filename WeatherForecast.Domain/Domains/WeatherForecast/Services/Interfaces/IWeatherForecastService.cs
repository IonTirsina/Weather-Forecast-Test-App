namespace TestApp.Domain.WeatherForecast
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> getForDays(int days);
        public IEnumerable<WeatherForecast> getForDateRange(DateTime fromDate, DateTime toDate);
    }
}
