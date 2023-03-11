using AutoMapper;
using Categories.Models;

namespace WebApi.Controllers.Categories.Models.AutoMapper
{
    public class CategoryResponseProfile : Profile
    {
        public CategoryResponseProfile() 
        {
            CreateMap<CategoryModel, CategoryResponse>();
        }
    }
}
