namespace Context.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryUser>? Followers { get; set; }
        public virtual ICollection<CategoryQuotation>? Quotations { get; set; }
    }
}
