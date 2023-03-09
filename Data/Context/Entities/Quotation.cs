namespace Context.Entities
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<CategoryQuotation>? Categories { get; set; }
    }
}
