using Subscriptions.Models;
using Users.Models;

namespace Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<UserModel>> GetFollowersByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetUsersByFollowerId(Guid followerId);
        Task Insert(SubscriptionModel model);
        Task Delete(SubscriptionModel model);
    }
}
