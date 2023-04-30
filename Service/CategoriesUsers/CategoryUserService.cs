using AutoMapper;
using Categories.Models;
using CategoriesUsers.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace CategoriesUsers
{
    public class CategoryUserService : ICategoryUserService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;

        public CategoryUserService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryUserModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesUsers = context.CategoriesUsers
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await categoriesUsers.ToListAsync())
                .Select(mapper.Map<CategoryUserModel>);
        }

        public async Task<CategoryUserModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = await context.CategoriesUsers.FindAsync(id);
            return categoryUser == null
                ? throw new ServiceException($"CategoryUser with id {id} wasn't found")
                : mapper.Map<CategoryUserModel>(categoryUser);
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesByUserId(Guid userId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesUsers = context.CategoriesUsers
                .Where(cu => cu.UserId.Equals(userId))
                .Join(context.Categories, cu => cu.CategoryId, c => c.Id, (cu, c) => c);
            return (await categoriesUsers.ToListAsync())
                .Select(mapper.Map<CategoryModel>);
        }

        public async Task<IEnumerable<UserModel>> GetUsersByCategoryId(int categoryId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoriesUsers = context.CategoriesUsers
                .Where(cu => cu.CategoryId.Equals(categoryId))
                .Join(context.Users, cu => cu.UserId, u => u.Id, (cu, u) => u);
            return (await categoriesUsers.ToListAsync())
                .Select(mapper.Map<UserModel>);
        }

        public async Task Insert(InsertCategoryUserModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = mapper.Map<CategoryUser>(model);
            await context.CategoriesUsers.AddAsync(categoryUser);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCategoryUserModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = await context.CategoriesUsers.FindAsync(id)
                ?? throw new ServiceException($"CategoryUser with id {id} wasn't found");
            categoryUser = mapper.Map(model, categoryUser);
            context.CategoriesUsers.Update(categoryUser);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = await context.CategoriesUsers.FindAsync(id)
                ?? throw new ServiceException($"CategoryUser with id {id} wasn't found");
            context.CategoriesUsers.Remove(categoryUser);
            await context.SaveChangesAsync();
        }
    }
}
