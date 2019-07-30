using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class MarriageAnniversaryReminderDto : ICommonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime? MarriageAnniversary { get; set; }
    }
}