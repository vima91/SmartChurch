using System.Collections.Generic;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class SendEmailDto
    {
        public string Subject;
        public string Body;
        public List<string> Emails;
    }
}