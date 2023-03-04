using Categories.Models;

namespace Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel> GetById(int id);
        Task Insert(InsertCategoryModel model);
        Task Update(UpdateCategoryModel model);
        Task Delete(int id);
    }
}
