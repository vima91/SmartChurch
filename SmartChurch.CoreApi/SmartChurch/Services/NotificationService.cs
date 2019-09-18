using System;
using System.Net;
using System.Net.Mail;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Infrastructure;

namespace SmartChurch.Services
{
    public interface INotificationService
    {
        string SendEmail(SendEmailDto dto);
    }

    public class NotificationService : INotificationService
    {
        public string SendEmail(SendEmailDto dto)
        {
            try
            {
                var credentials = new NetworkCredential(SiriusConfiguration.EmailUserName, SiriusConfiguration.EmailPassword);

                var mail = new MailMessage
                {
                    From = new MailAddress(SiriusConfiguration.EmailUserName),
                    Subject = dto.Subject,
                    Body = dto.Body,
                    IsBodyHtml = true
                };

                foreach (var email in dto.Emails)
                {
                    mail.To.Add(new MailAddress(email));
                }

                var client = new SmtpClient
                {
                    Host = SiriusConfiguration.EmailHost,
                    Port = Convert.ToInt32(SiriusConfiguration.EmailPort),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);

                return "Email(s) Sent Successfully!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}