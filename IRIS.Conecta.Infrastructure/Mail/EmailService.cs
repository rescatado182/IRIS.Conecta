using IRIS.Conecta.Application.Contracts.Infrastructure;
using IRIS.Conecta.Application.Models.Email;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IRIS.Conecta.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSettings _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(Email email)
        {
            var smtpServer      = _emailSettings.SmtpServer;
            var smtpPort        = int.Parse(_emailSettings.SmtpPort);
            var smtpUsername    = _emailSettings.SmptUsername;
            var smtpPassword    = _emailSettings.SmptPassword;
            var senderEmail     = _emailSettings.FromAddress;
            var senderName      = _emailSettings.FromName;

            var client = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email.To);

            await client.SendMailAsync(mailMessage);

            client.Dispose();
        }
    }
}
