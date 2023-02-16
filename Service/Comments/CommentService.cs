using Categories.Models;

namespace Comments
{
    public class CommentService : ICommentService
    {
        public Task<CommentModel> AddComment(AddCommentModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentModel> GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentModel>> GetComments()
        {
            throw new NotImplementedException();
        }

        public Task UpdateComment(int id, UpdateCommentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
