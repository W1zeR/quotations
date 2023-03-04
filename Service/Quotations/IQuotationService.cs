using Categories.Models;

namespace Quotations
{
    public interface IQuotationService
    {
        Task<IEnumerable<QuotationModel>> GetAll(int offset = 0, int limit = 10);
        Task<QuotationModel> GetById(int id);
        Task Insert(InsertQuotationModel model);
        Task Update(UpdateQuotationModel model);
        Task Delete(int id);
    }
}
