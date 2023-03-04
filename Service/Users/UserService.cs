using Categories.Models;

namespace Users
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(InsertUserModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateUserModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
