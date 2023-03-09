using AutoMapper;
using Context.Entities;

namespace Quotations.Models.AutoMapper
{
    public class QuotationModelProfile : Profile
    {
        public QuotationModelProfile()
        {
            CreateMap<Quotation, QuotationModel>();
        }
    }
}
