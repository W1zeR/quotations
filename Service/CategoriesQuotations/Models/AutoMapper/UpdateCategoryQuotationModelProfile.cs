using AutoMapper;
using Context.Entities;

namespace CategoriesQuotations.Models.AutoMapper
{
    public class UpdateCategoryQuotationModelProfile : Profile
    {
        public UpdateCategoryQuotationModelProfile() 
        {
            CreateMap<UpdateCategoryQuotationModel, CategoryQuotation>();
        }
    }
}
