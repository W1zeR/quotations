using Categories.Models;

namespace Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        public Task<SubscriptionModel> AddSubscription(AddSubscriptionModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubscription(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubscriptionModel> GetSubscription(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubscriptionModel>> GetSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubscription(int id, UpdateSubscriptionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
