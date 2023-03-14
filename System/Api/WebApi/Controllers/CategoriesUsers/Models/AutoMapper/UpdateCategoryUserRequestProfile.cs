using AutoMapper;
using CategoriesUsers.Models;

namespace WebApi.Controllers.CategoriesUsers.Models.AutoMapper
{
    public class UpdateCategoryUserRequestProfile : Profile
    {
        public UpdateCategoryUserRequestProfile() 
        {
            CreateMap<UpdateCategoryUserRequest, UpdateCategoryUserModel>();
        }
    }
}
