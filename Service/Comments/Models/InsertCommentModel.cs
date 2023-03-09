namespace Comments.Models
{
    public class InsertCommentModel
    {
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public Guid UserId { get; set; }
        public int QuotationId { get; set; }
    }
}
