namespace Quotations.Models
{
    public class UpdateQuotationModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
