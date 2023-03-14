namespace WebApi.Controllers.Quotations.Models
{
    public class QuotationResponse : QuotationMessageWithoutId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
