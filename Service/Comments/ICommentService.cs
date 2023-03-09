using Comments.Models;

namespace Comments
{
    public interface ICommentService
    {
        Task<CommentModel> GetById(int id);
        Task<IEnumerable<CommentModel>> GetByQuotationId(int quotationId);
        Task<IEnumerable<CommentModel>> GetByUserId(Guid userId);
        Task Insert(InsertCommentModel model);
        Task Update(UpdateCommentModel model);
        Task Delete(int id);
    }
}
