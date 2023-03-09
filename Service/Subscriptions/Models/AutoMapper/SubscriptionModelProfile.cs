using AutoMapper;
using Context.Entities;

namespace Subscriptions.Models.AutoMapper
{
    public class SubscriptionModelProfile : Profile
    {
        public SubscriptionModelProfile()
        {
            CreateMap<Subscription, SubscriptionModel>();
        }
    }
}
