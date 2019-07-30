using System;
using System.ComponentModel.DataAnnotations;

namespace SmartChurch.DataModel.Models.Core
{
    public abstract class AuditableEntity
    {
        [Timestamp]
        public byte[] Stamp { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}