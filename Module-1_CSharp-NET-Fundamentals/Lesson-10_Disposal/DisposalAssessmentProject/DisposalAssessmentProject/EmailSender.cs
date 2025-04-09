using System.Net;
using System.Net.Mail;

namespace DisposalAssessmentProject
{
    internal class EmailSender : IDisposable
    {
        private SmtpClient _smtpClient;
        private bool _disposed = false;

        public EmailSender()
        {
            _smtpClient = new SmtpClient("smtp.mail.ru", 587)
            {
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true,
                Timeout = 150000,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }

        public void SendEmail(string toEmail)
        {
            var mailMessage = new MailMessage("", toEmail)
            {
                Subject = "Thanks for subscribing!",
                Body = "We appreciate your interest in our newsletter!"
            };

            _smtpClient.Send(mailMessage);
            mailMessage.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _smtpClient?.Dispose();
                }

                _disposed = true;
            }
        }

        ~EmailSender()
        {
            Dispose(false);
        }
    }
}
