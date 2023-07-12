﻿using TestApp.Models;
using TestApp.Utils.WeatherForecast;

namespace TestApp.Services
{
    public class WeatherForecastService
    {
        public IEnumerable<WeatherForecast> getForDays(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of days should be greater than 0");
            }

            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = WeatherForecastUtils.generateRandomCelsiusTemperature()
            }).ToArray();
        }

        public IEnumerable<WeatherForecast> getForDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate >= toDate)
            {
                throw new ArgumentException("Dates are in wrong consecutiveness");
            }

            var differenceInDays = toDate.Subtract(fromDate).Days;
            
            return Enumerable.Range(1, differenceInDays).Select(index => new WeatherForecast
            {
                Date = fromDate.AddDays(index),
                TemperatureC = WeatherForecastUtils.generateRandomCelsiusTemperature()
            }).ToArray();
        }
    }
}
