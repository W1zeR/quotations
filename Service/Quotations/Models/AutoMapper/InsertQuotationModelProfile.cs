using AutoMapper;
using Context.Entities;

namespace Quotations.Models.AutoMapper
{
    public class InsertQuotationModelProfile : Profile
    {
        public InsertQuotationModelProfile()
        {
            CreateMap<InsertQuotationModel, Quotation>();
        }
    }
}
