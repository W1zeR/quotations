using AutoMapper;
using Context.Entities;

namespace Subscriptions.Models.AutoMapper
{
    public class InsertSubscriptionModelProfile : Profile
    {
        public InsertSubscriptionModelProfile() 
        {
            CreateMap<InsertSubscriptionModel, Subscription>();
        }
    }
}
