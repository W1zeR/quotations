using AutoMapper;
using Context.Entities;

namespace CategoriesQuotations.Models.AutoMapper
{
    public class CategoryQuotationModelProfile : Profile
    {
        public CategoryQuotationModelProfile()
        {
            CreateMap<CategoryQuotation, CategoryQuotationModel>();
        }
    }
}
