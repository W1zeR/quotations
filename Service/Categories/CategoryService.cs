using AutoMapper;
using Categories.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IValidator<InsertCategoryModel> insertCategoryModelValidator;
        private readonly IValidator<UpdateCategoryModel> updateCategoryModelValidator;

        public CategoryService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IValidator<InsertCategoryModel> insertCategoryModelValidator,
            IValidator<UpdateCategoryModel> updateCategoryModelValidator
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.insertCategoryModelValidator = insertCategoryModelValidator;
            this.updateCategoryModelValidator = updateCategoryModelValidator;
        }

        public async Task<IEnumerable<CategoryModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categories = context.Categories
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await categories.ToListAsync())
                .Select(mapper.Map<CategoryModel>);
        }

        public async Task<CategoryModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var category = await context.Categories.FindAsync(id);
            return category == null ? throw new ServiceException($"Category with id {id} wasn't found") :
                mapper.Map<CategoryModel>(category);
        }

        public async Task Insert(InsertCategoryModel model)
        {
            await insertCategoryModelValidator.ValidateAndThrowAsync(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var category = mapper.Map<Category>(model);
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCategoryModel model)
        {
            await updateCategoryModelValidator.ValidateAndThrowAsync(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var category = await context.Categories.FindAsync(id)
                ?? throw new ServiceException($"Category with id {id} wasn't found");
            category = mapper.Map(model, category);
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var category = await context.Categories.FindAsync(id)
                ?? throw new ServiceException($"Category with id {id} wasn't found");
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }
    }
}
