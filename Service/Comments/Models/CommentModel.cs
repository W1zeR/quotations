namespace Comments.Models
{
    public class CommentModel : CommentModelWithoutId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
