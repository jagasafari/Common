namespace Common.Mailer
{
    public interface IMailService
    {
        void Send();
        MailService BuildMailMessage(string subject, string content);
    }
}