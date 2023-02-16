using Categories.Models;

namespace Quotations
{
    public interface IQuotationService
    {
        Task<IEnumerable<QuotationModel>> GetQuotations(int offset = 0, int limit = 10);
        Task<QuotationModel> GetQuotation(int id);
        Task<QuotationModel> AddQuotation(AddQuotationModel model);
        Task UpdateQuotation(int id, UpdateQuotationModel model);
        Task DeleteQuotation(int id);
    }
}
