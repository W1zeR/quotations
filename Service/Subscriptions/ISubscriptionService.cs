using Subscriptions.Models;
using Users.Models;

namespace Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionModel>> GetAll(int offset = 0, int limit = 10);
        Task<SubscriptionModel> GetById(int id);
        Task<IEnumerable<UserModel>> GetFollowersByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetUsersByFollowerId(Guid followerId);
        Task Insert(InsertSubscriptionModel model);
        Task Update(int id, UpdateSubscriptionModel model);
        Task Delete(int id);
    }
}
