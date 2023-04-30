namespace Mails.Models
{
    public class MailModel
    {
        public IEnumerable<string> To { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
