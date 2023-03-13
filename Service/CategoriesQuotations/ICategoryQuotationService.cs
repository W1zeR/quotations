using Categories.Models;
using CategoriesQuotations.Models;
using Quotations.Models;

namespace CategoriesQuotations
{
    public interface ICategoryQuotationService
    {
        Task<IEnumerable<CategoryQuotationModel>> GetAll(int offset = 0, int limit = 10);
        Task<CategoryQuotationModel> GetById(int id);
        Task<IEnumerable<CategoryModel>> GetCategoriesByQuotationId(int id);
        Task<IEnumerable<QuotationModel>> GetQuotationsByCategoryId(int id);
        Task Insert(InsertCategoryQuotationModel model);
        Task Update(int id, UpdateCategoryQuotationModel model);
        Task Delete(int id);
    }
}