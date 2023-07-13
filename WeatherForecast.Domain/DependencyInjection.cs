using Microsoft.Extensions.DependencyInjection;
using TestApp.Domain.WeatherForecast;

namespace TestApp.Domain.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void InjectDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        }
    }
}
