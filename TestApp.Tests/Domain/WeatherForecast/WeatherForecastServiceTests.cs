using TestApp.Domain.WeatherForecast;

namespace TestApp.Tests.Domain.WeatherForecast
{
    [TestClass]
    public class WeatherForecastServiceTests
    {
        private WeatherForecastService _weatherForecastService = new WeatherForecastService();

        /// <summary>
        /// Ensures that resulted forecast returns  the number of forecasts which was requeste
        /// </summary>
        [TestMethod]
        public void WeatherForecast_ForDays_EnsureNumberOfForecasts()
        {
            //Arrange
            const int getForecastForDays = 5;

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDays(getForecastForDays);


            // Assert
            var resultedNumberOfForecasts = resultedWeatherForecast.Count();

            Assert.AreEqual(getForecastForDays, resultedNumberOfForecasts);
        }

        [TestMethod]
        public void WeatherForecast_ForDays_ShouldStartWithNextDay()
        {
            //Arrange
            const int getForecastForDays = 5;
            DateTime nextDay = DateTime.Now.AddDays(1);

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDays(getForecastForDays);

            // Assert
            var firstResultedForecast = resultedWeatherForecast.First();
            var firstResultedForecastIsNextDay = nextDay.DayOfYear == firstResultedForecast.Date.DayOfYear && nextDay.Year == firstResultedForecast.Date.Year;

            Assert.IsTrue(firstResultedForecastIsNextDay);
        }

        [TestMethod]
        public void WeatherForecast_ForDays_ShouldEndAccordingToQuery()
        {
            //Arrange
            const int getForecastForDays = 5;
            DateTime expectedEndOfForecast = DateTime.Now.AddDays(getForecastForDays);

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDays(getForecastForDays);

            // Assert
            var lastResultedForecast = resultedWeatherForecast.Last();
            var lastResultedForecastIsAccordingToQuery = expectedEndOfForecast.DayOfYear == lastResultedForecast.Date.DayOfYear && expectedEndOfForecast.Year == lastResultedForecast.Date.Year;

            Assert.IsTrue(lastResultedForecastIsAccordingToQuery);
        }

        [TestMethod]
        public void WeatherForecast_ForDays_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            const int invalidNumberOfDays = 0;

            // Act
            var resultedForecastFn = () => _weatherForecastService.GetForDays(invalidNumberOfDays);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(resultedForecastFn);
        }

        [TestMethod]
        public void WeatherForecast_ForRange_EnsureNumberOfForecasts()
        {
            //Arrange
            const int rangePeriod = 7; // days between from date and to date
            const int expectedNumberOfForecasts = rangePeriod + 1; // +1 so it includes the "fromDate"
            DateTime fromDate = DateTime.Now;
            DateTime toDate = fromDate.AddDays(rangePeriod);

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDateRange(fromDate, toDate);
            var resultedNumberOfForecasts = resultedWeatherForecast.Count();

            // Assert
            Assert.AreEqual(resultedNumberOfForecasts, expectedNumberOfForecasts);
        }

        [TestMethod]
        public void WeatherForecast_ForRange_ShouldStartFromRange()
        {
            //Arrange
            const int rangePeriod = 7; // days between from date and to date
            DateTime fromDate = DateTime.Now;
            DateTime toDate = fromDate.AddDays(rangePeriod);

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDateRange(fromDate, toDate);

            // Assert
            var firstResultedForecast = resultedWeatherForecast.First();
            var firstResultedForecastIsNextDay = fromDate.DayOfYear == firstResultedForecast.Date.DayOfYear && fromDate.Year == firstResultedForecast.Date.Year;

            Assert.IsTrue(firstResultedForecastIsNextDay);
        }


        [TestMethod]
        public void WeatherForecast_ForRange_ShouldEndAccordingToQuery()
        {
            //Arrange
            const int rangePeriod = 7; // days between from date and to date
            DateTime fromDate = DateTime.Now;
            DateTime toDate = fromDate.AddDays(rangePeriod);

            // Act
            var resultedWeatherForecast = _weatherForecastService.GetForDateRange(fromDate, toDate);

            // Assert
            var lastResultedForecast = resultedWeatherForecast.Last();
            var lastResultedForecastIsAccordingToRange = toDate.DayOfYear == lastResultedForecast.Date.DayOfYear && toDate.Year == lastResultedForecast.Date.Year;

            Assert.IsTrue(lastResultedForecastIsAccordingToRange);
        }

        [TestMethod]
        public void WeatherForecast_ForRange_ThrowArgumentException()
        {
            //Arrange
            DateTime fromDate = DateTime.Now;
            DateTime invalidToDate = fromDate.AddDays(-1);

            // Act
            var resultedForecastFn = () => _weatherForecastService.GetForDateRange(fromDate, invalidToDate);

            // Assert
            Assert.ThrowsException<ArgumentException>(resultedForecastFn);
        }
    }
}
