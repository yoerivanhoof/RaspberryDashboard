namespace RaspberryDashboard_Backend.Models
{
    public class DiscordUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public string ChannelId { get; set; }

        public bool Muted { get; set; }
        public bool Deafend { get; set; }
    }
}