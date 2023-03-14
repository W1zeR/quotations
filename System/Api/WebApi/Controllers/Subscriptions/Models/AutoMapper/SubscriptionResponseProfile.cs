using AutoMapper;
using Subscriptions.Models;

namespace WebApi.Controllers.Subscriptions.Models.AutoMapper
{
    public class SubscriptionResponseProfile : Profile
    {
        public SubscriptionResponseProfile() 
        {
            CreateMap<SubscriptionModel, SubscriptionResponse>();
        }
    }
}
