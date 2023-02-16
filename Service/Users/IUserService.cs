using Categories.Models;

namespace Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> AddUser(AddUserModel model);
        Task UpdateUser(int id, UpdateUserModel model);
        Task DeleteUser(int id);
    }
}
