using RaspberryDashboard_Backend.Models;

namespace RaspberryDashboard_Backend.Services
{
    public interface IWeatherService
    {
        public OpenWeather GetWeather(string location);
    }
}