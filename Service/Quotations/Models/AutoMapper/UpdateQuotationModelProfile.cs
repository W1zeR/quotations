using AutoMapper;
using Context.Entities;

namespace Quotations.Models.AutoMapper
{
    public class UpdateQuotationModelProfile : Profile
    {
        public UpdateQuotationModelProfile()
        {
            CreateMap<UpdateQuotationModel, Quotation>();
        }
    }
}
