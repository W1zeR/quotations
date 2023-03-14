using AutoMapper;
using CategoriesQuotations.Models;

namespace WebApi.Controllers.CategoriesQuotations.Models.AutoMapper
{
    public class UpdateCategoryQuotationRequestProfile : Profile
    {
        public UpdateCategoryQuotationRequestProfile() 
        {
            CreateMap<UpdateCategoryQuotationRequest, UpdateCategoryQuotationModel>();
        }
    }
}
