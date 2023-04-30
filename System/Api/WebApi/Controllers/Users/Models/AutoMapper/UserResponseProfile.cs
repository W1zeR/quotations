using AutoMapper;
using Users.Models;

namespace WebApi.Controllers.Users.Models.AutoMapper
{
    public class UserResponseProfile : Profile
    {
        public UserResponseProfile()
        {
            CreateMap<UserModel, UserResponse>();
        }
    }
}
