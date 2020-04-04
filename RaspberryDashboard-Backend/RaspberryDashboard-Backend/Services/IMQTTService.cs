using System.Threading.Tasks;

namespace RaspberryDashboard_Backend.Services
{
    public interface IMqttService
    {
        public Task PublishMessage(string topic, string payload);
    }
}