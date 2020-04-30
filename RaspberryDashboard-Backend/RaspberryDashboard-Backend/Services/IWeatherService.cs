using RaspberryDashboard_Backend.Models.Weather;

namespace RaspberryDashboard_Backend.Services
{
    public interface IWeatherService
    {
        public OpenWeather GetWeather(string location);
    }
}