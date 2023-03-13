using AutoMapper;
using CategoriesQuotations.Models;

namespace WebApi.Controllers.CategoriesQuotations.Models.AutoMapper
{
    public class CategoryQuotationRequestProfile : Profile
    {
        public CategoryQuotationRequestProfile() 
        {
            CreateMap<CategoryQuotationRequest, CategoryQuotationModel>();
        }
    }
}
