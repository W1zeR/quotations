using AutoMapper;
using Quotations.Models;

namespace WebApi.Controllers.Quotations.Models.AutoMapper
{
    public class InsertQuotationRequestProfile : Profile
    {
        public InsertQuotationRequestProfile() 
        {
            CreateMap<InsertQuotationRequest, InsertQuotationModel>();
        }
    }
}
