namespace Quotations.Models
{
    public class QuotationModelWithoutId
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
