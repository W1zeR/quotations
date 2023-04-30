using AutoMapper;
using Context.Entities;

namespace Users.Models.AutoMapper
{
    public class RegisterUserModelProfile : Profile
    {
        public RegisterUserModelProfile() 
        { 
            CreateMap<RegisterUserModel, User>();
        }
    }
}
