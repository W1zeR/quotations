using AutoMapper;
using Context.Entities;

namespace CategoriesUsers.Models.AutoMapper
{
    public class CategoryUserModelProfile : Profile
    {
        public CategoryUserModelProfile()
        {
            CreateMap<CategoryUser, CategoryUserModel>();
        }
    }
}
