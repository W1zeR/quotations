using Categories.Models;
using CategoriesUsers.Models;
using Users.Models;

namespace CategoriesUsers
{
    public interface ICategoryUserService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetUsersByCategoryId(int categoryId);
        Task Insert(CategoryUserModel model);
        Task Delete(CategoryUserModel model);
    }
}