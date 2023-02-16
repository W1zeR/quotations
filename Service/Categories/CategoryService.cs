using Categories.Models;

namespace Categories
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryModel> AddCategory(AddCategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(int id, UpdateCategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
