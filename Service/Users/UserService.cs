using AutoMapper;
using Common.Exceptions;
using Context.Entities;
using Microsoft.AspNetCore.Identity;
using Users.Models;

namespace Users
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserService(
            IMapper mapper,
            UserManager<User> userManager
        )
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UserModel> Register(RegisterUserModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                throw new ServiceException($"User with email {model.Email} already exists");
            }
            user = GetUserFromRegisterUserModel(model);
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new ServiceException($"Error while creating user: {GetIdentityErrorDescriptions(result)}");
            }
            return mapper.Map<UserModel>(user);
        }

        private static string GetIdentityErrorDescriptions(IdentityResult result) 
        {
            return string.Join(", ", result.Errors.Select(s => s.Description));
        }

        private static User GetUserFromRegisterUserModel(RegisterUserModel model)
        {
            return new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = false
            };
        }
    }
}
