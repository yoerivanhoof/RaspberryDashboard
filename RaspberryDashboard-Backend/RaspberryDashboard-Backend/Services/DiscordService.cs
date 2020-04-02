using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace RaspberryDashboard_Backend.Services
{
    public class DiscordService: IDiscordService
    {
        private DiscordSocketClient _client;

        public DiscordService()
        {
            MainAsync();
        }


        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            // Remember to keep token private or to read it from an 
            // external source! In this case, we are reading the token 
            // from an environment variable. If you do not know how to set-up
            // environment variables, you may find more information on the 
            // Internet or by using other methods such as reading from 
            // a configuration.
            await _client.LoginAsync(TokenType.Bot,
                Environment.GetEnvironmentVariable("DiscordBotToken"));
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        public async void MoveToAFK()
        {
            _client.GetGuild(377533648620093441).GetUser(220164841166471168)
                .ModifyAsync(user => user.ChannelId = 426351658482663454);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                Console.WriteLine(message.Author.Id);
                _client.GetGuild(377533648620093441).GetUser(message.Author.Id)
                    .ModifyAsync(user => user.ChannelId = 426351658482663454);


                //await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}