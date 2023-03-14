using AutoMapper;
using Quotations.Models;

namespace WebApi.Controllers.Quotations.Models.AutoMapper
{
    public class QuotationResponseProfile : Profile
    {
        public QuotationResponseProfile() 
        {
            CreateMap<QuotationModel, QuotationResponse>();
        }
    }
}
