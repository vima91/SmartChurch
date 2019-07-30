using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SmartChurch.Services.Core
{
    public class SiriusEmailSenderService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //TODO: Implement email server if need be
            return Task.CompletedTask;
        }
    }
}