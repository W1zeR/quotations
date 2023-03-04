using Categories.Models;

namespace Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetAll();
        Task<CommentModel> GetById(int id);
        Task Insert(InsertCommentModel model);
        Task Update(UpdateCommentModel model);
        Task Delete(int id);
    }
}
