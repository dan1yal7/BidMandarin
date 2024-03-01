using BidMandarin.Models;
using System.Net.Mail;
using System.Net;

namespace BidMandarin.Methods
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            using (var smtpClient = new SmtpClient("smtp.example.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("your_username", "your_password");
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your_email@example.com"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
            }

        }
    }
}
  