using Mails.Models;

namespace Mails
{
    public interface IMailService
    {
        Task SendAsync(MailModel mail, CancellationToken ct);
    }
}
