using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AgentFinder.Identity.Models.Provider
{
    public class AgentCustomerProvider : IUserIdProvider
    {
        public static Guid? FindUserId(string name)
        {
            return null;
        }

        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}
