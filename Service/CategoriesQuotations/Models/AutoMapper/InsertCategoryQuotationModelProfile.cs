using AutoMapper;
using Context.Entities;

namespace CategoriesQuotations.Models.AutoMapper
{
    public class InsertCategoryQuotationModelProfile : Profile
    {
        public InsertCategoryQuotationModelProfile() 
        {
            CreateMap<InsertCategoryQuotationModel, CategoryQuotation>();
        }
    }
}
