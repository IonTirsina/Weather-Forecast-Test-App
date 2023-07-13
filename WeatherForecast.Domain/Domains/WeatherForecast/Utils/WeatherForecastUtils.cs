namespace TestApp.Domain.WeatherForecast
{
    public class WeatherForecastUtils
    {
        public static WeatherForecastSummary GetSummaryFromTemperature(int temperatureC)
        {
            var allSummaries = Enum.GetValues(typeof(WeatherForecastSummary)).Cast<WeatherForecastSummary>();
            var closestTemperatureSummary = allSummaries.OrderBy((summaryTemp) => Math.Abs((int)summaryTemp - temperatureC)).First();

            return closestTemperatureSummary;
        }

        public static int ConvertCelsiusToFarenheit(int temperatureC)  => 32 + (int)(temperatureC / 0.5556);

        public static int GenerateRandomCelsiusTemperature() => Random.Shared.Next(WeatherForecastConstants.MinCelsiusTemperature, WeatherForecastConstants.MaxCelsiusTemperature);
    }
}
