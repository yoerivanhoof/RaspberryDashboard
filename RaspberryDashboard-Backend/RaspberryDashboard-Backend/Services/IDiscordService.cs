using System.Threading.Tasks;

namespace RaspberryDashboard_Backend.Services
{
    public interface IDiscordService
    {
        public Task MainAsync();

        public void MoveToAFK();

        public string GetCurrent();
    }
}