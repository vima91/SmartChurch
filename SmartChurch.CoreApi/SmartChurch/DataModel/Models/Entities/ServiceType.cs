using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class ServiceType : SiriusDeletableEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public bool IsNotLinkableToPersons { get; set; }
    }
}