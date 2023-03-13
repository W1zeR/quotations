using AutoMapper;
using Context.Entities;

namespace Subscriptions.Models.AutoMapper
{
    public class UpdateSubscriptionModelProfile : Profile
    {
        public UpdateSubscriptionModelProfile()
        {
            CreateMap<UpdateSubscriptionModel, Subscription>();
        }
    }
}
