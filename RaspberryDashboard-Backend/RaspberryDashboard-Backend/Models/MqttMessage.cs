namespace RaspberryDashboard_Backend.Models
{
    public class MqttMessage
    {
        public string Topic { get; set; }
        public string Payload { get; set; }
    }
}