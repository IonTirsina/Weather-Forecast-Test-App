namespace TestApp.Domain.WeatherForecast
{
    public class WeatherForecastService: IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetForDays(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of days should be greater than 0");
            }

            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = WeatherForecastUtils.GenerateRandomCelsiusTemperature()
            }).ToArray();
        }

        public IEnumerable<WeatherForecast> GetForDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate >= toDate)
            {
                throw new ArgumentException("Dates are in wrong consecutiveness");
            }

            var differenceInDays = toDate.Subtract(fromDate).Days;
            
            return Enumerable.Range(0, differenceInDays + 1).Select(index => new WeatherForecast
            {
                Date = fromDate.AddDays(index),
                TemperatureC = WeatherForecastUtils.GenerateRandomCelsiusTemperature()
            }).ToArray();
        }
    }
}
