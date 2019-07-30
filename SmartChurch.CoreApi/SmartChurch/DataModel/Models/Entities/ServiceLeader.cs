using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class ServiceLeader : SiriusDeletableEntity
    {
        [Required]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}