namespace WebApi.Controllers.Subscriptions.Models
{
    public class SubscriptionMessageWithoutId
    {
        public Guid UserId { get; set; }
        public Guid FollowerId { get; set; }
    }
}
