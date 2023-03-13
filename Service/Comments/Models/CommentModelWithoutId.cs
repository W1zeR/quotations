namespace Comments.Models
{
    public class CommentModelWithoutId
    {
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public Guid UserId { get; set; }
        public int QuotationId { get; set; }
    }
}
