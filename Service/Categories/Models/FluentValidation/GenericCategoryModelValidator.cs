using Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Categories.Models.FluentValidation
{
    public class GenericCategoryModelValidator<T> : AbstractValidator<T> where T : CategoryModelWithoutId
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public GenericCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    bool exists = await IsNameExists(name);
                    return !exists;
                })
                .WithMessage("Category name already exists");
        }

        private async Task<bool> IsNameExists(string name)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var category = await context.Categories
                .Where(c => c.Name.ToLower() == name.ToLower())
                .SingleOrDefaultAsync();
            return category != null;
        }
    }
}
