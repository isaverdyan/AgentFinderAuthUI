using AgentFinder.Identity.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IHubContext<NotificationHub, INotificationHubClient> _notificationHub;

        public NotificationController(IHubContext<NotificationHub, INotificationHubClient> notificationHub)
        {
            _notificationHub = notificationHub;
        }
    }
}
