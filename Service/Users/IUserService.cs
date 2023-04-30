using Users.Models;

namespace Users
{
    public interface IUserService
    {
        Task<UserModel> Register(RegisterUserModel model);
    }
}
