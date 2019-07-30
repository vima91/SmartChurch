using System.ComponentModel.DataAnnotations;

namespace SmartChurch.DataModel.Models.Core
{
    public abstract class SiriusEntity : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
    }
}