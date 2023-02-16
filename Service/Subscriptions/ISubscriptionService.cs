using Categories.Models;

namespace Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionModel>> GetSubscriptions();
        Task<SubscriptionModel> GetSubscription(int id);
        Task<SubscriptionModel> AddSubscription(AddSubscriptionModel model);
        Task UpdateSubscription(int id, UpdateSubscriptionModel model);
        Task DeleteSubscription(int id);
    }
}
