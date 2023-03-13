using AutoMapper;
using Context.Entities;

namespace CategoriesUsers.Models.AutoMapper
{
    public class UpdateCategoryUserModelProfile : Profile
    {
        public UpdateCategoryUserModelProfile() 
        {
            CreateMap<UpdateCategoryUserModel, CategoryUser>();
        }
    }
}
