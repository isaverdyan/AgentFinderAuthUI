using AgentFinder.Identity.Context;
using AgentFinder.Identity.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        private IHubContext<NotificationHub, INotificationHubClient> _notificationHub;

        public NotificationController(AppDbContext authContext, IHubContext<NotificationHub, INotificationHubClient> notificationHub)
        {
            _notificationHub = notificationHub;
            _authContext = authContext;
        }

        [HttpPost]
        [Route("offers")]
        public string SendOffers()
        {
            List<string> offers = new List<string>();
            offers.Add("4800, 10% off on Almidor Ave., Woodland hills");
            offers.Add("15% Off on Gavina ave., Sylmar");
            offers.Add("25% Off on Blythe st., North hollywood");
            _notificationHub.Clients.All.SendOffersToUser(offers);
            return "Offers sent successfully to all users!";
        }
    }
}
