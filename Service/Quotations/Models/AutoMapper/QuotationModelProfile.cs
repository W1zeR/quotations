using AutoMapper;
using Context.Entities;

namespace Quotations.Models.AutoMapper
{
    public class QuotationModelProfile : Profile
    {
        public QuotationModelProfile()
        {
            CreateMap<Quotation, QuotationModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
