namespace Quotations.Models
{
    public class QuotationModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;

        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
    }
}
