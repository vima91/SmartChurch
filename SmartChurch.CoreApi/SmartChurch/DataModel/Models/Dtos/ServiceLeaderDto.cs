using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ServiceLeaderDto : ICommonDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
    }
}