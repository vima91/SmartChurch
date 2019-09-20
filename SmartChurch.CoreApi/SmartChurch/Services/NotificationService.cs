using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using SmartChurch.DataAccess;
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
        private readonly SiriusDbContext _context;

        public NotificationService(SiriusDbContext context)
        {
            _context = context;
        }
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

                var emails = GetPersonEmailsByServiceId(dto.ServiceId);

                foreach (var email in emails)
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

        #region Helpers

        private List<string> GetPersonEmailsByServiceId(int serviceId)
        {
            var personIds = _context.ServiceSubscriptions
                .Where(s => s.ServiceId == serviceId)
                .Select(s => s.PersonId);
            var emails = _context.Persons
                .Where(s => personIds
                    .Contains(s.Id))
                .Select(s => s.Email)
                .Where(s => !string
                    .IsNullOrEmpty(s))
                .ToList();

            return emails;
        }

        #endregion
    }
}