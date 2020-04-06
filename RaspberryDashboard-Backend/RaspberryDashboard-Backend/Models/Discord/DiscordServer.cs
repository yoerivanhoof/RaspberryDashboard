using System.Collections.Generic;

namespace RaspberryDashboard_Backend.Models.Discord
{
    public class DiscordServer
    {
        public List<DiscordVoiceChannel> VoiceChannels { get; set; } = new List<DiscordVoiceChannel>();
    }
}