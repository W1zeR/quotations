using Quotations.Models;

namespace Quotations
{
    public interface IQuotationService
    {
        Task<IEnumerable<QuotationModel>> GetAll(int offset = 0, int limit = 10);
        Task<QuotationModel> GetById(int id);
        Task<IEnumerable<QuotationModel>> GetByUserId(Guid userId);
        Task Insert(InsertQuotationModel model);
        Task Update(UpdateQuotationModel model);
        Task Delete(int id);
    }
}
