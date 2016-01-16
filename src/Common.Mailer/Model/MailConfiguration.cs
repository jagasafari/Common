namespace Common.Mailer.Model
{
    using Common.Core;

    public class MailConfiguration
    {
        private string _sender;
        private string _password;
        private int _smtpPort;
        private string _smtpHost;
        private string _receiver;
        public string Sender { get { return _sender; } set { _sender = Check.NotNullOrWhiteSpace(value, nameof(value)); } }
        public string Password { get { return _password; } set { _password = Check.NotNullOrWhiteSpace(value, nameof(value)); } }
        public int SmtpPort { get { return _smtpPort; } set { _smtpPort = Check.NotNegative(value, nameof(value)); } }
        public string SmtpHost { get { return _smtpHost; } set { _smtpHost = Check.NotNullOrWhiteSpace(value, nameof(value)); } }
        public string Receiver { get { return _receiver; } set { _receiver = Check.NotNullOrWhiteSpace(value, nameof(value)); } }
    }
}