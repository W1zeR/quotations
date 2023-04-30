using AutoMapper;
using Users.Models;

namespace WebApi.Controllers.Users.Models.AutoMapper
{
    public class RegisterUserRequestProfile : Profile
    {
        public RegisterUserRequestProfile()
        {
            CreateMap<RegisterUserRequest, RegisterUserModel>();
        }
    }
}
