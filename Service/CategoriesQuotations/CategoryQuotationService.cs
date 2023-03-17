using AutoMapper;
using Categories.Models;
using CategoriesQuotations.Models;
using Common.Exceptions;
using Common.ModelValidator;
using Context;
using Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quotations.Models;

namespace CategoriesQuotations
{
    public class CategoryQuotationService : ICategoryQuotationService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<InsertCategoryQuotationModel> insertCategoryQuotationModelValidator;
        private readonly IModelValidator<UpdateCategoryQuotationModel> updateCategoryQuotationModelValidator;

        public CategoryQuotationService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IModelValidator<InsertCategoryQuotationModel> insertCategoryQuotationModelValidator,
            IModelValidator<UpdateCategoryQuotationModel> updateCategoryQuotationModelValidator
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.insertCategoryQuotationModelValidator = insertCategoryQuotationModelValidator;
            this.updateCategoryQuotationModelValidator = updateCategoryQuotationModelValidator;
        }

        public async Task<IEnumerable<CategoryQuotationModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesQuotations = context.CategoriesQuotations
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await categoriesQuotations.ToListAsync())
                .Select(mapper.Map<CategoryQuotationModel>);
        }

        public async Task<CategoryQuotationModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = await context.CategoriesQuotations.FindAsync(id);
            return categoryQuotation == null ? 
                throw new ServiceException($"CategoryQuotation with id {id} wasn't found") :
                mapper.Map<CategoryQuotationModel>(categoryQuotation);
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

        public async Task<IEnumerable<QuotationModel>> GetQuotationsByCategoryId(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesQuotations = context.CategoriesQuotations
                .Where(cq => cq.CategoryId.Equals(id))
                .Join(context.Quotations, cq => cq.QuotationId, q => q.Id, (cq, q) => q);
            return (await categoriesQuotations.ToListAsync())
                .Select(mapper.Map<QuotationModel>);
        }

        public async Task Insert(InsertCategoryQuotationModel model)
        {
            await insertCategoryQuotationModelValidator.CheckAsync(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = mapper.Map<CategoryQuotation>(model);
            await context.CategoriesQuotations.AddAsync(categoryQuotation);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCategoryQuotationModel model)
        {
            await updateCategoryQuotationModelValidator.CheckAsync(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = await context.CategoriesQuotations.FindAsync(id)
                ?? throw new ServiceException($"CategoryQuotation with id {id} wasn't found");
            categoryQuotation = mapper.Map(model, categoryQuotation);
            context.CategoriesQuotations.Update(categoryQuotation);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryQuotation = await context.CategoriesQuotations.FindAsync(id)
                ?? throw new ServiceException($"CategoryQuotation with id {id} wasn't found");
            context.CategoriesQuotations.Remove(categoryQuotation);
            await context.SaveChangesAsync();
        }
    }
}
