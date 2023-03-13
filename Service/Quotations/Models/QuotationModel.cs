namespace Quotations.Models
{
    public class QuotationModel : QuotationModelWithoutId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
