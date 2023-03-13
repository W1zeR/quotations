using AutoMapper;
using CategoriesQuotations.Models;

namespace WebApi.Controllers.CategoriesQuotations.Models.AutoMapper
{
    public class CategoryQuotationResponseProfile : Profile
    {
        public CategoryQuotationResponseProfile() 
        {
            CreateMap<CategoryQuotationModel, CategoryQuotationResponse>();
        }
    }
}
