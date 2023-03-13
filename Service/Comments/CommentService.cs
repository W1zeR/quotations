using AutoMapper;
using Comments.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Comments
{
    public class CommentService : ICommentService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IValidator<InsertCommentModel> insertCommentModelValidator;
        private readonly IValidator<UpdateCommentModel> updateCommentModelValidator;

        public CommentService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IValidator<InsertCommentModel> insertCommentModelValidator,
            IValidator<UpdateCommentModel> updateCommentModelValidator
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.insertCommentModelValidator = insertCommentModelValidator;
            this.updateCommentModelValidator = updateCommentModelValidator;
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
            insertCommentModelValidator.ValidateAndThrow(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var comment = mapper.Map<Comment>(model);
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCommentModel model)
        {
            updateCommentModelValidator.ValidateAndThrow(model);
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
