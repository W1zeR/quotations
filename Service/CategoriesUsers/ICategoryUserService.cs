using Categories.Models;
using CategoriesUsers.Models;
using Users.Models;

namespace CategoriesUsers
{
    public interface ICategoryUserService
    {
        Task<IEnumerable<CategoryUserModel>> GetAll(int offset = 0, int limit = 10);
        Task<CategoryUserModel> GetById(int id);
        Task<IEnumerable<CategoryModel>> GetCategoriesByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetUsersByCategoryId(int categoryId);
        Task Insert(InsertCategoryUserModel model);
        Task Update(int id, UpdateCategoryUserModel model);
        Task Delete(int id);
    }
}