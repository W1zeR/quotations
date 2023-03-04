using Categories.Models;

namespace Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task Insert(InsertUserModel model);
        Task Update(UpdateUserModel model);
        Task Delete(int id);
    }
}
