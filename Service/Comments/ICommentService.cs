using Comments.Models;

namespace Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetAll(int offset = 0, int limit = 10);
        Task<CommentModel> GetById(int id);
        Task<IEnumerable<CommentModel>> GetByQuotationId(int quotationId);
        Task<IEnumerable<CommentModel>> GetByUserId(Guid userId);
        Task Insert(InsertCommentModel model);
        Task Update(int id, UpdateCommentModel model);
        Task Delete(int id);
    }
}
