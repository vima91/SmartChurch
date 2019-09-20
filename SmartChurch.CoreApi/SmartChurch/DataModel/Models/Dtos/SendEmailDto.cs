namespace SmartChurch.DataModel.Models.Dtos
{
    public class SendEmailDto
    {
        public string Subject;
        public string Body;
        public int ServiceId { get; set; }
    }
}