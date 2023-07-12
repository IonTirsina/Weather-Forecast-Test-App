using TestApp.Enums;

namespace TestApp.Utils.WeatherForecast
{
    public class WeatherForecastUtils
    {
        public static WeatherForecastSummary getSummaryFromTemperature(int temperatureC)
        {
            var allSummaries = Enum.GetValues(typeof(WeatherForecastSummary)).Cast<WeatherForecastSummary>();
            var closestTemperatureSummary = allSummaries.OrderBy((summaryTemp) => Math.Abs((int)summaryTemp - temperatureC)).First();

            return closestTemperatureSummary;
        }
    }
}
