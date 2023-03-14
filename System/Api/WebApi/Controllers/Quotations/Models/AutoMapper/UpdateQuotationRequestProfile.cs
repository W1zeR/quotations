using AutoMapper;
using Quotations.Models;

namespace WebApi.Controllers.Quotations.Models.AutoMapper
{
    public class UpdateQuotationRequestProfile : Profile
    {
        public UpdateQuotationRequestProfile() 
        {
            CreateMap<UpdateQuotationRequest, UpdateQuotationModel>();
        }
    }
}
