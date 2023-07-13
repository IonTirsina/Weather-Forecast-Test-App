namespace TestApp.Domain.WeatherForecast
{
    /// <summary>
    /// Contains a relationship between a F temperature summary and the approximate temperature this summary describes.
    /// </summary>
    public enum WeatherForecastSummary
    {
        Freezing = 0,
        Bracing = 5,
        Chilly = 10,
        Cool = 15, 
        Mild = 20,
        Warm = 25,
        Balmy = 30,
        Hot = 35,
        Sweltering = 40,
        Scorching = 50
    }
}
