namespace EmailSender.Controllers.Mails.Models
{
    public class MailRequest
    {
        public IEnumerable<string> To { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
