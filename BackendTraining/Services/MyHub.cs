using Microsoft.AspNetCore.SignalR;

namespace GymAppTraining.Api.Services
{
    public class MyHub : Hub
    {
        public async Task SendData(string data)
        {
            await Clients.All.SendAsync("data", data);
        }
    }
}
