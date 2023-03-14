using AutoMapper;
using Subscriptions.Models;

namespace WebApi.Controllers.Subscriptions.Models.AutoMapper
{
    public class UpdateSubscriptionRequestProfile : Profile
    {
        public UpdateSubscriptionRequestProfile() 
        {
            CreateMap<UpdateSubscriptionRequest, UpdateSubscriptionModel>();
        }
    }
}
