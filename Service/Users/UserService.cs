using Categories.Models;

namespace Users
{
    public class UserService : IUserService
    {
        public Task<UserModel> AddUser(AddUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(int id, UpdateUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
