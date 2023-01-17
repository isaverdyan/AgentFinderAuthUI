using Microsoft.AspNetCore.SignalR;

namespace AgentFinder.Identity.Hubs;

    public class NotificationHub : Hub<INotificationHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
