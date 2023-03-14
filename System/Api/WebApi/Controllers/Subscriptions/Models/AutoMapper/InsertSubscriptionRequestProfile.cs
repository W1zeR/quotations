using AutoMapper;
using Subscriptions.Models;

namespace WebApi.Controllers.Subscriptions.Models.AutoMapper
{
    public class InsertSubscriptionRequestProfile : Profile
    {
        public InsertSubscriptionRequestProfile() 
        {
            CreateMap<InsertSubscriptionRequest, InsertSubscriptionModel>();
        }
    }
}
