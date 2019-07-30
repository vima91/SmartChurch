using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class BirthdayReminderDto : ICommonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime? Birthday { get; set; }
    }
}