using AutoMapper;
using Context.Entities;

namespace CategoriesUsers.Models.AutoMapper
{
    public class InsertCategoryUserModelProfile : Profile
    {
        public InsertCategoryUserModelProfile() 
        {
            CreateMap<InsertCategoryUserModel, CategoryUser>();
        }
    }
}
