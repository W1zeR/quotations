namespace Quotations.Models
{
    public class UpdateQuotationModel
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
