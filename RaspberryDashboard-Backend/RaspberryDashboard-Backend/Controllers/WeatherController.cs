using Microsoft.AspNetCore.Mvc;
using RaspberryDashboard_Backend.Services;

namespace RaspberryDashboard_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // GET: api/Weather
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_weatherService.GetWeather("Eersel")); //todo
        }

    }
}