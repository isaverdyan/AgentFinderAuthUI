using Microsoft.AspNetCore.SignalR;

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
