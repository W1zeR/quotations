using Categories.Models;

namespace Quotations
{
    public class QuotationService : IQuotationService
    {
        public async Task<IEnumerable<QuotationModel>> GetAll(int offset = 0, int limit = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<QuotationModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(InsertQuotationModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateQuotationModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
