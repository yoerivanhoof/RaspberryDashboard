using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaspberryDashboard_Backend.JsonContractResolver;
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
        [HttpGet("{place}")]
        public ActionResult Get(string place)
        {
            return Ok(JsonConvert.SerializeObject(_weatherService.GetWeather(place), new JsonSerializerSettings
            {
                ContractResolver = new LongNameContractResolver()
            }));
        }
    }
}