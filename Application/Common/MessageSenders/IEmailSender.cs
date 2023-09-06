using System.Net.Mail;

namespace Application.Common.MessageSenders
{
    public interface IEmailSender
    {
        void SendEmail(MailMessage message);
    }
}
