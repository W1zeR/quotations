namespace Quotations.Models
{
    public class InsertQuotationModel
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
