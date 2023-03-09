using AutoMapper;
using Categories.Models;
using CategoriesUsers.Models;
using Common.Exceptions;
using Context;
using Context.Entities;
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

        public async Task Insert(CategoryUserModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = mapper.Map<CategoryUser>(model);
            await context.CategoriesUsers.AddAsync(categoryUser);
            await context.SaveChangesAsync();
        }

        public async Task Delete(CategoryUserModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var categoryUser = await context.CategoriesUsers.FindAsync(model.CategoryId, model.UserId)
                ?? throw new ServiceException($"CategoryUser with CategoryId {model.CategoryId} " +
                $"and UserId {model.UserId} wasn't found");
            context.CategoriesUsers.Remove(categoryUser);
            await context.SaveChangesAsync();
        }
    }
}
