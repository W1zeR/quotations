namespace Context.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = null!;
    }
}
