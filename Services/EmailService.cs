using Quote_genarator.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Quote_genarator.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress("your-email@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mail.To.Add(to);

            await smtpClient.SendMailAsync(mail);
        }
    }
}
