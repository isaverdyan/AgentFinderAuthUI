namespace AgentFinder.Identity.Hubs
{
    public interface INotificationHubClient
    {
        Task SendOffersToUser(List<string> message);
    }
}
