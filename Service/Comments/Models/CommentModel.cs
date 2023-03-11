namespace Comments.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;

        public int QuotationId { get; set; }
    }
}
