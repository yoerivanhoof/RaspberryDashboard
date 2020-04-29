using RaspberryDashboard_Backend.Models;

namespace RaspberryDashboard_Backend.Services
{
    public interface IWeatherService
    {
        public string GetWeather(string location);
    }
}