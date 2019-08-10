using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ServiceDto : ICommonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsWeekly { get; set; }
        public int? Weekday { get; set; }
        public int ServiceTypeId { get; set; }
        public string Comment { get; set; }
        public string DayOfWeek { get; set; }
    }
}