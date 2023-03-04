using Categories.Models;

namespace Comments
{
    public class CommentService : ICommentService
    {
        public async Task<IEnumerable<CommentModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CommentModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(InsertCommentModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateCommentModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
