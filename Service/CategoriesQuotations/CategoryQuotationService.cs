using AutoMapper;
using Categories.Models;
using CategoriesQuotations.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Quotations.Models;

namespace CategoriesQuotations
{
    public class CategoryQuotationService : ICategoryQuotationService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;

        public CategoryQuotationService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesByQuotationId(int quotationId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesQuotations = context.CategoriesQuotations
                .Where(cq => cq.QuotationId.Equals(quotationId))
                .Join(context.Categories, cq => cq.CategoryId, c => c.Id, (cq, c) => c);
            return (await categoriesQuotations.ToListAsync())
                .Select(mapper.Map<CategoryModel>);
        }

        public async Task<IEnumerable<QuotationModel>> GetQuotationsByCategoryId(int categoryId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesQuotations = context.CategoriesQuotations
                .Where(cq => cq.CategoryId.Equals(categoryId))
                .Join(context.Quotations, cq => cq.QuotationId, q => q.Id, (cq, q) => q);
            return (await categoriesQuotations.ToListAsync())
                .Select(mapper.Map<QuotationModel>);
        }

        public async Task Insert(CategoryQuotationModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = mapper.Map<CategoryQuotation>(model);
            await context.CategoriesQuotations.AddAsync(categoryQuotation);
            await context.SaveChangesAsync();
        }

        public async Task Delete(CategoryQuotationModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = await context.CategoriesQuotations.FindAsync(model.CategoryId, model.QuotationId)
                ?? throw new ServiceException($"CategoryQuotation with CategoryId {model.CategoryId} " +
                $"and QuotationId {model.QuotationId} wasn't found");
            context.CategoriesQuotations.Remove(categoryQuotation);
            await context.SaveChangesAsync();
        }
    }
}
