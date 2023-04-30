using Common.Settings;
using MailKit.Security;
using Mails.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Mails
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> settings)
        {
            mailSettings = settings.Value;
        }

        public async Task SendAsync(MailModel mail, CancellationToken ct = default)
        {
            var message = new MimeMessage
            {
                Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.From)
            };

            foreach (string mailAddress in mail.To)
            {
                message.To.Add(MailboxAddress.Parse(mailAddress));
            }

            var body = new BodyBuilder();
            message.Subject = mail.Subject;
            body.HtmlBody = mail.Body;
            message.Body = body.ToMessageBody();

            using var smtp = new SmtpClient();

            if (mailSettings.UseSSL)
            {
                await smtp.ConnectAsync(mailSettings.Host, mailSettings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (mailSettings.UseStartTls)
            {
                await smtp.ConnectAsync(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls, ct);
            }
            await smtp.AuthenticateAsync(mailSettings.UserName, mailSettings.Password, ct);
            await smtp.SendAsync(message, ct);
            await smtp.DisconnectAsync(true, ct);
        }
    }
}
