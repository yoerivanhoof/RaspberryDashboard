using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.WebSocket;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RaspberryDashboard_Backend.Hubs;
using RaspberryDashboard_Backend.Models;

namespace RaspberryDashboard_Backend.Services
{
    public class DiscordService: IDiscordService
    {
        private DiscordSocketClient _client;
        private readonly IHubContext<DiscordHub> _hub;

        public DiscordService(IHubContext<DiscordHub> hub)
        {
            _hub = hub;
#pragma warning disable 4014
            MainAsync(); //Dont await this (it blocks the rest of the api)
#pragma warning restore 4014
        }


        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
            _client.UserVoiceStateUpdated += client_UserVoiceStateUpdated;

            await _client.LoginAsync(TokenType.Bot,
                Environment.GetEnvironmentVariable("DiscordBotToken"));
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }


        private async Task client_UserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
        {
            await _hub.Clients.All.SendCoreAsync("VoiceStateUpdated", new[] {""});
        }

        public string GetCurrentState()
        {
            if (_client.ConnectionState != ConnectionState.Connected)
                return ""; //in case we get an api  call before the client is connected.
            
            var server = new DiscordServer();
            foreach (var voiceChannel in _client.GetGuild(377533648620093441).VoiceChannels.OrderBy(x=>x.Position))
            {
                var channel = new DiscordVoiceChannel(){Id = voiceChannel.Id.ToString(), Name = voiceChannel.Name};

                foreach (var channelUser in voiceChannel.Users)
                {
                    channel.Users.Add(new DiscordUser()
                    {
                        Id = channelUser.Id.ToString(), 
                        Username = !string.IsNullOrEmpty(channelUser.Nickname) ? channelUser.Nickname : channelUser.Username, 
                        AvatarUrl = channelUser.GetAvatarUrl(), 
                        Deaf = channelUser.IsDeafened, 
                        Muted = channelUser.IsMuted, 
                        ChannelId = voiceChannel.Id.ToString()
                    });
                    
                }
                server.VoiceChannels.Add(channel);
            }

            return JsonConvert.SerializeObject(server);
        }

        public void UpdateUser(DiscordUser discordUser)
        {
            _client.GetGuild(377533648620093441).GetUser(Convert.ToUInt64(discordUser.Id)).ModifyAsync(user =>
            {
                user.ChannelId = Convert.ToUInt64(discordUser.ChannelId);
                user.Mute = discordUser.Muted;
                user.Deaf = discordUser.Deaf;
            });
        }
        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine($"Discord.Net {msg.ToString()}");
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            switch (message.Content.ToLower())
            {
                case "!ping":
                    await message.Channel.SendMessageAsync($"Nee {message.Author.Username}");
                    break;
                case "!boobs":
                    await message.Channel.SendMessageAsync($"https://www.dumpert.nl/tag/boobs");
                    break;
                case "!kick":
                    await _client.GetGuild(377533648620093441).GetUser(message.Author.Id).ModifyAsync(user =>
                        {
                            user.ChannelId = _client.GetGuild(377533648620093441).AFKChannel.Id;
                        });
                    break;
                case "!join":
                    _client.GetGuild(377533648620093441).VoiceChannels.First().ConnectAsync();
                    break;
            }
        }
    }
}