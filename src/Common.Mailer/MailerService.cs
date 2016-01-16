namespace Common.Mailer
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Logging;
    using Model;

    public class MailService : IMailService
    {
        private readonly MailConfiguration _mailConfiguration;

        private readonly Func<string, string> _formatSubject;
        private MailMessage _mailMessage;
        private ILogger<MailService> _logger;

        public MailService(MailConfiguration mailConfiguration,
            Func<string, string> formatSubject, ILogger<MailService> logger)
        {
            _mailConfiguration = mailConfiguration;
            _formatSubject = formatSubject;
            _logger = logger;
        }

        public void Send()
        {
            using (var smtpClient = CreateSmtClient())
            {
                smtpClient.Send(_mailMessage);
            }
        }

        public MailService BuildMailMessage(string subject, string content)
        {
            _mailMessage = new MailMessage(_mailConfiguration.Sender,
                _mailConfiguration.Receiver, _formatSubject(subject),
                content);
            return this;
        }

        private SmtpClient CreateSmtClient()
        {
            _logger.LogInformation($"creating SmtpClient on port {_mailConfiguration.SmtpPort}");
            return new SmtpClient(_mailConfiguration.SmtpHost, _mailConfiguration.SmtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_mailConfiguration.Sender, _mailConfiguration.Password)
            };
        }
    }
}