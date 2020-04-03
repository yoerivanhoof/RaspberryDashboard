using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaspberryDashboard_Backend.Services;

namespace RaspberryDashboard_Backend.Hubs
{
    public class DiscordHub : Hub
    {
        public DiscordHub(IDiscordService discordService)
        {
        }
    }
}