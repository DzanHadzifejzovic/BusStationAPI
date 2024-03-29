using Domain.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmailAsync(string to,string subject, string body)
        {
            var mail = _config.GetSection("EmailUsername").Value;
            var pw = _config.GetSection("EmailPassword").Value;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(mail));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };


            var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(mail, pw);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
