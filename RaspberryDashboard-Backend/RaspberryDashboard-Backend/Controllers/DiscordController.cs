using Microsoft.AspNetCore.Mvc;
using RaspberryDashboard_Backend.Services;

namespace RaspberryDashboard_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordController : ControllerBase
    {
        private IDiscordService _discordService;
        public DiscordController(IDiscordService discordService)
        {
            _discordService = discordService;
        }

        [HttpGet]
        public string Get()
        {
            _discordService.MoveToAFK();
            return "done";
        }
    }
}