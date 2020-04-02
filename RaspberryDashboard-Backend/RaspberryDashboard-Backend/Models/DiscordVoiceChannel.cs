using System.Collections.Generic;

namespace RaspberryDashboard_Backend.Models
{
    public class DiscordVoiceChannel
    {
        public List<DiscordUser> users = new List<DiscordUser>();
        public ulong id;
        public string name;
    }
}