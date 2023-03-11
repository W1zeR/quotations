using AutoMapper;
using Common.Exceptions;
using Context;
using Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quotations.Models;

namespace Quotations
{
    public class QuotationService : IQuotationService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IValidator<InsertQuotationModel> insertQuotationModelValidator;
        private readonly IValidator<UpdateQuotationModel> updateQuotationModelValidator;

        public QuotationService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IValidator<InsertQuotationModel> insertQuotationModelValidator,
            IValidator<UpdateQuotationModel> updateQuotationModelValidator
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.insertQuotationModelValidator = insertQuotationModelValidator;
            this.updateQuotationModelValidator = updateQuotationModelValidator;
        }

        public async Task<IEnumerable<QuotationModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var quotations = context.Quotations
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await quotations.ToListAsync())
                .Select(mapper.Map<QuotationModel>);
        }

        public async Task<QuotationModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var quotation = await context.Quotations.FindAsync(id);
            return quotation == null ? throw new ServiceException($"Quotation with id {id} wasn't found") :
                mapper.Map<QuotationModel>(quotation);
        }

        public async Task<IEnumerable<QuotationModel>> GetByUserId(Guid userId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var quotations = context.Quotations
                .Where(q => q.UserId.Equals(userId));
            return (await quotations.ToListAsync())
                .Select(mapper.Map<QuotationModel>);
        }

        public async Task Insert(InsertQuotationModel model)
        {
            var validationResult = insertQuotationModelValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            using var context = await contextFactory.CreateDbContextAsync();
            var quotation = mapper.Map<Quotation>(model);
            await context.Quotations.AddAsync(quotation);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateQuotationModel model)
        {
            var validationResult = updateQuotationModelValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            using var context = await contextFactory.CreateDbContextAsync();
            var quotation = await context.Quotations.FindAsync(id)
                ?? throw new ServiceException($"Quotation with id {id} wasn't found");
            quotation = mapper.Map(model, quotation);
            context.Quotations.Update(quotation);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var quotation = await context.Quotations.FindAsync(id)
                ?? throw new ServiceException($"Quotation with id {id} wasn't found");
            context.Quotations.Remove(quotation);
            await context.SaveChangesAsync();
        }
    }
}
