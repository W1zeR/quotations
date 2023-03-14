using AutoMapper;
using CategoriesUsers.Models;

namespace WebApi.Controllers.CategoriesUsers.Models.AutoMapper
{
    public class CategoryUserResponseProfile : Profile
    {
        public CategoryUserResponseProfile() 
        {
            CreateMap<CategoryUserModel, CategoryUserResponse>();
        }
    }
}
