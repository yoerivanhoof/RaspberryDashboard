using Microsoft.AspNetCore.Mvc;
using RaspberryDashboard_Backend.Services;

namespace RaspberryDashboard_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordController : ControllerBase
    {
        private readonly IDiscordService _discordService;
        public DiscordController(IDiscordService discordService)
        {
            _discordService = discordService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_discordService.GetCurrent());
        }
    }
}