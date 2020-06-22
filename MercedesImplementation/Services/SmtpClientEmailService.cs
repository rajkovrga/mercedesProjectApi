using Application.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Implementation.Services
{
    public class SmtpClientEmailService : IEmailService
    {
        public void EmailSender(string email, string body)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("pitanja.odgovori.primer@gmail.com","primerprimer")
            };
            var mail = new MailMessage("pitanja.odgovori.primer@gmail.com", email);
            mail.Subject = "Mercedes company";
            mail.IsBodyHtml = true;
            mail.Body = body;
            smtp.Send(mail);
        }
    }
}
