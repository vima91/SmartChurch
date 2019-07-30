using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ServiceSubscriptionDto : ICommonDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PersonId { get; set; }
    }
}