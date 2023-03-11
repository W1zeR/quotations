using Categories.Models;

namespace Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAll(int offset = 0, int limit = 10);
        Task<CategoryModel> GetById(int id);
        Task Insert(InsertCategoryModel model);
        Task Update(int id, UpdateCategoryModel model);
        Task Delete(int id);
    }
}
