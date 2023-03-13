namespace WebApi.Controllers.Subscriptions.Models
{
    public class SubscriptionRequest
    {
        public Guid UserId { get; set; }
        public Guid FollowerId { get; set; }
    }
}
