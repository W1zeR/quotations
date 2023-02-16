using Categories.Models;

namespace Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetComments();
        Task<CommentModel> GetComment(int id);
        Task<CommentModel> AddComment(AddCommentModel model);
        Task UpdateComment(int id, UpdateCommentModel model);
        Task DeleteComment(int id);
    }
}
