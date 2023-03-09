namespace Context.Entities
{
    public class CategoryQuotation
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = null!;
    }
}
