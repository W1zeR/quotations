using Categories.Models;

namespace Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionModel>> GetAll();
        Task<SubscriptionModel> GetById(int id);
        Task Insert(InsertSubscriptionModel model);
        Task Update(UpdateSubscriptionModel model);
        Task Delete(int id);
    }
}
