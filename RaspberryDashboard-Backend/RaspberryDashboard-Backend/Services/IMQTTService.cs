using System.Threading.Tasks;
using MQTTnet.Client.Publishing;

namespace RaspberryDashboard_Backend.Services
{
    public interface IMqttService
    {
        public MqttClientPublishResult PublishMessage(string topic, string payload);
    }
}