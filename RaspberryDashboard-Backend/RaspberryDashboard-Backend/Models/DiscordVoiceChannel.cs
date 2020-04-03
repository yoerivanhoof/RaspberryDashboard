using System.Collections.Generic;

namespace RaspberryDashboard_Backend.Models
{
    public class DiscordVoiceChannel
    {
        public List<DiscordUser> Users { get; set; } = new List<DiscordUser>();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}