using Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CategoriesQuotations.Models.FluentValidation
{
    public class GenericCategoryQuotationModelValidator<T> : AbstractValidator<T> where T : CategoryQuotationModelWithoutId
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public GenericCategoryQuotationModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;

            RuleFor(x => x.QuotationId)
                .MustAsync(async (id, cancellation) =>
                {
                    return await IsQuotationHasLessThanFiveCategories(id);
                })
                .WithMessage("Quotation can't have more than 5 categories");
        }

        private async Task<bool> IsQuotationHasLessThanFiveCategories(int quotationId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            int categoriesCount = await context.CategoriesQuotations
                .Where(cq => cq.QuotationId == quotationId)
                .CountAsync();
            return categoriesCount < 5;
        }
    }
}
