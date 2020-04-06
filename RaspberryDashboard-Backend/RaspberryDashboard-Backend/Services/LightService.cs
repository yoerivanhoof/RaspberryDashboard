namespace RaspberryDashboard_Backend.Services
{
    public class LightService : ILightService
    {
        private readonly IMqttService _mqttService;

        public LightService(IMqttService mqttService)
        {
            _mqttService = mqttService;
        }
    }
}