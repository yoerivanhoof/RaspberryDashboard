using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace RaspberryDashboard_Backend.Services
{
    public class MqttService : IMqttService
    {
        private readonly IMqttClient _client;
        private readonly IMqttClientOptions _options;
        public MqttService()
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();
            _options = new MqttClientOptionsBuilder()
                .WithClientId("RaspberryDashboard")
                .WithTcpServer("192.168.2.20")
                .WithCleanSession()
                .Build();

            _client.ConnectAsync(_options, CancellationToken.None);

            _client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("MQTT Connected");
            });

            _client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();
            });
        }


        public async Task PublishMessage(string topic, string payload)
        {
            if (_client.IsConnected)
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(Encoding.UTF8.GetBytes(payload))
                    .WithExactlyOnceQoS()
                    .Build();

                await _client.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
            }
        }


    }
}