using Mails.Models;

namespace Actions
{
    public interface IAction
    {
        void SendEmail(MailModel email);
    }
}
