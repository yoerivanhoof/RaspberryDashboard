using System.Threading.Tasks;
using RaspberryDashboard_Backend.Models;
using RaspberryDashboard_Backend.Models.Discord;

namespace RaspberryDashboard_Backend.Services
{
    public interface IDiscordService
    {
        public Task MainAsync();

        public string GetCurrentState();

        public void UpdateUser(DiscordUser discordUser);
    }
}