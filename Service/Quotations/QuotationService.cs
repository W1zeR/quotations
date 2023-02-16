using Categories.Models;

namespace Quotations
{
    public class QuotationService : IQuotationService
    {
        public Task<QuotationModel> AddQuotation(AddQuotationModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuotation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<QuotationModel> GetQuotation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuotationModel>> GetQuotations(int offset = 0, int limit = 10)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuotation(int id, UpdateQuotationModel model)
        {
            throw new NotImplementedException();
        }
    }
}
