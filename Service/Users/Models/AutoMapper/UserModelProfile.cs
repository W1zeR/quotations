using AutoMapper;
using Context.Entities;

namespace Users.Models.AutoMapper
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
