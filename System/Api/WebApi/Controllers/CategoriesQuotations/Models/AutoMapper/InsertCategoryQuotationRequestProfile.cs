using AutoMapper;
using CategoriesQuotations.Models;

namespace WebApi.Controllers.CategoriesQuotations.Models.AutoMapper
{
    public class InsertCategoryQuotationRequestProfile : Profile
    {
        public InsertCategoryQuotationRequestProfile() 
        {
            CreateMap<InsertCategoryQuotationRequest, InsertCategoryQuotationModel>();
        }
    }
}
