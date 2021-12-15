using System;
using System.Net;
using System.Net.Mail;

namespace Food4U_SEP3.Service
{
    public class EmailService : IEmailService
    {
        const string password = "Food4U1234";

        SmtpClient smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("app.food4u@gmail.com", password)
        };

        public void SendEmail(string subject, string body, string receiver)
        {
            using (MailMessage message = new MailMessage("app.food4u@gmail.com", receiver)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
        }
    }
}