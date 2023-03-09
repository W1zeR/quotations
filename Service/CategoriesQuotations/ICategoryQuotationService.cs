using Categories.Models;
using CategoriesQuotations.Models;
using Quotations.Models;

namespace CategoriesQuotations
{
    public interface ICategoryQuotationService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesByQuotationId(int quotationId);
        Task<IEnumerable<QuotationModel>> GetQuotationsByCategoryId(int categoryId);
        Task Insert(CategoryQuotationModel model);
        Task Delete(CategoryQuotationModel model);
    }
}