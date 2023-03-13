namespace CategoriesUsers.Models
{
    public class CategoryUserModelWithoutId
    {
        public int CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
