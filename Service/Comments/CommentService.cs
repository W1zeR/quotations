using AutoMapper;
using Comments.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments
{
    public class CommentService : ICommentService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;

        public CommentService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CommentModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comments = context.Comments
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await comments.ToListAsync())
                .Select(mapper.Map<CommentModel>);
        }

        public async Task<CommentModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comment = await context.Comments.FindAsync(id);
            return comment == null ? throw new ServiceException($"Comment with id {id} wasn't found") :
                mapper.Map<CommentModel>(comment);
        }

        public async Task<IEnumerable<CommentModel>> GetByQuotationId(int quotationId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comments = context.Comments
                .Where(c => c.QuotationId.Equals(quotationId));
            return (await comments.ToListAsync())
                .Select(mapper.Map<CommentModel>);
        }

        public async Task<IEnumerable<CommentModel>> GetByUserId(Guid userId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comments = context.Comments
                .Where(c => c.UserId.Equals(userId));
            return (await comments.ToListAsync())
                .Select(mapper.Map<CommentModel>);
        }

        public async Task Insert(InsertCommentModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comment = mapper.Map<Comment>(model);
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCommentModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comment = await context.Comments.FindAsync(id)
                ?? throw new ServiceException($"Comment with id {id} wasn't found");
            comment = mapper.Map(model, comment);
            context.Comments.Update(comment);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comment = await context.Comments.FindAsync(id)
                ?? throw new ServiceException($"Comment with id {id} wasn't found");
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }
}
