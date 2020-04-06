namespace RaspberryDashboard_Backend.Models.Discord
{
    public class DiscordUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public string ChannelId { get; set; }

        public bool Muted { get; set; }
        public bool Deaf { get; set; }
        public bool SelfMuted { get; set; }
        public bool SelfDeaf { get; set; }
        public bool Bot { get; set; }
    }
}