namespace Context.Entities
{
    public class CategoryUser
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
