using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RaspberryDashboard_Backend.Hubs
{
    public class DashboardHub : Hub
    {
        public async Task NewMessage(string msg)
        {
            Console.WriteLine(msg);
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}