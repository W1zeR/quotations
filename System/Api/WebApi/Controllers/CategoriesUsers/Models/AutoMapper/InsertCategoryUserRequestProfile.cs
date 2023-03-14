using AutoMapper;
using CategoriesUsers.Models;

namespace WebApi.Controllers.CategoriesUsers.Models.AutoMapper
{
    public class InsertCategoryUserRequestProfile : Profile
    {
        public InsertCategoryUserRequestProfile() 
        {
            CreateMap<InsertCategoryUserRequest, InsertCategoryUserModel>();
        }
    }
}
