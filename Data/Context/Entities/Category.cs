namespace Context.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Followers { get; set; } = null!;
        public virtual ICollection<Quotation> Quotations { get; set; } = null!;
    }
}
