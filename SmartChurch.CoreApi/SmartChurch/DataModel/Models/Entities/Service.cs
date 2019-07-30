using System;
using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class Service : SiriusDeletableEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        [Required]
        public bool IsWeekly { get; set; }
        public int? Weekday { get; set; }

        [Required]
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }

        public string Comment { get; set; }
    }
}