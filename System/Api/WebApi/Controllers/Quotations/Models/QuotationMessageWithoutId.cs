namespace WebApi.Controllers.Quotations.Models
{
    public class QuotationMessageWithoutId
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
