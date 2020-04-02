using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.WebSocket;
using Newtonsoft.Json;
using RaspberryDashboard_Backend.Models;

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
            
            //_client.UserVoiceStateUpdated += _client_UserVoiceStateUpdated;

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

        private async Task _client_UserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
        {
            Console.WriteLine(user.Username);
            if (before.IsMuted == false && after.IsMuted == true)
            {
                user.SendMessageAsync("you got muted");
            }
        }

        public string GetCurrent()
        {
            var server = new DiscordServer();
            foreach (var voiceChannel in _client.GetGuild(377533648620093441).VoiceChannels.OrderBy(x=>x.Position))
            {
                var channel = new DiscordVoiceChannel(){id = voiceChannel.Id, name = voiceChannel.Name};

                foreach (var channelUser in voiceChannel.Users)
                {
                    channel.users.Add(new DiscordUser(){id = channelUser.Id, username = channelUser.Username, avatarUrl = channelUser.GetAvatarUrl()});
                    
                }
                server.voiceChannels.Add(channel);
            }

            return JsonConvert.SerializeObject(server);
        }

        public async void MoveToAFK()
        {
            var audioclient = await _client.GetGuild(377533648620093441).VoiceChannels.First().ConnectAsync();
            SendAsync(audioclient, "C:\\Users\\TheRiverVan\\source\\repos\\RaspberryDashboard\\RaspberryDashboard-Backend\\RaspberryDashboard-Backend\\bin\\Debug\\netcoreapp3.1\\defqon.mp3").GetAwaiter().OnCompleted(
                () =>
                {
                    _client.GetGuild(377533648620093441).VoiceChannels.First().DisconnectAsync();
                });
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

            if (message.Content == "!join")
            {
                
                

            }
        }

        private Process CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            });
        }

        private async Task SendAsync(IAudioClient client, string path)
        {
            // Create FFmpeg using the previous example
            using (var ffmpeg = CreateStream(path))
            using (var output = ffmpeg.StandardOutput.BaseStream)
            using (var discord = client.CreatePCMStream(AudioApplication.Mixed))
            {
                try { await output.CopyToAsync(discord); }
                finally { await discord.FlushAsync(); }
            }
        }
    }
}