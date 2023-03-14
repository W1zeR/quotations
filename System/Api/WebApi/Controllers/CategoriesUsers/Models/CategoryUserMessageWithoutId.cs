namespace WebApi.Controllers.CategoriesUsers.Models
{
    public class CategoryUserMessageWithoutId
    {
        public int CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
