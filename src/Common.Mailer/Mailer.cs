namespace Common.Mailer
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using Model;

    public class Mailer
    {
        private readonly MailConfiguration _mailConfiguration;

        private readonly Func<string, string> _formatSubject;
        private MailMessage _mailMessage;

        public Mailer(MailConfiguration mailConfiguration,
            Func<string, string> formatSubject)
        {
            _mailConfiguration = mailConfiguration;
            _formatSubject = formatSubject;
        }

        public void Send()
        {
            using(var smtpClient = CreateSmtClient())
            {
                smtpClient.Send(_mailMessage);
            }
        }

        public Mailer BuildMailMessage(string subject, string content)
        {
            _mailMessage = new MailMessage(_mailConfiguration.Sender,
                _mailConfiguration.Receiver, _formatSubject(subject),
                content);
            return this;
        }

        private SmtpClient CreateSmtClient() =>
            new SmtpClient(_mailConfiguration.SmtpHost,
                _mailConfiguration.SmtpPort)
            {
                EnableSsl = true,
                Credentials =
                    new NetworkCredential(_mailConfiguration.Sender,
                        _mailConfiguration.Password)
            };
    }
}