namespace WebApi.Controllers.Comments.Models
{
    public class CommentResponse : CommentMessageWithoutId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
