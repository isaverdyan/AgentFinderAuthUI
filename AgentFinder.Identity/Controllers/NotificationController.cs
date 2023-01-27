using AgentFinder.Identity.Context;
using AgentFinder.Identity.Filters;
using AgentFinder.Identity.Hubs;
using AgentFinder.Identity.Models;
using AgentFinder.Identity.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AgentFinder.Identity.Controllers
{
    [Route("api/notification")]
    [ApiController]
    [SecurityHeaders]
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
        //[Authorize]
        public async Task<IActionResult> SendOffers([FromBody] dynamic messageVal)
        {
            var identity = Thread.CurrentPrincipal.Identity;
            //var request = Context.Request;
            var offers = new List<string>();
            var objModel1 = JsonConvert.DeserializeObject<dynamic>(messageVal.ToString());
            try
            {
                var objModel = JsonConvert.SerializeObject(objModel1.messageModel);
                
                MessageBody model = JsonConvert.DeserializeObject<MessageBody>(objModel);

                var customersMessages = JsonConvert.DeserializeObject<List<MessageOfferDto>>(model.Customers.ToString());

                foreach (var msg in customersMessages)
                {
                    var userId = msg.User.UserId;
                    offers.Add(model.MessageText);

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            
            await _notificationHub.Clients.All.SendOffersToUser(offers);
            return Ok("Offers sent successfully to all users!");
        }
    }
}
