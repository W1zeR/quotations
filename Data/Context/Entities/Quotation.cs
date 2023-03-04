namespace Context.Entities
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; } = null!;
        public virtual ICollection<CategoryQuotation> Categories { get; set; } = null!;
    }
}
