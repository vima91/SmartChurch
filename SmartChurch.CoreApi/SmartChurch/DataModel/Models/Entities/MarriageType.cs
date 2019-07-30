using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class MarriageType : SiriusDeletableEntity
    {
        [Required]
        public string Name { get; set; }
    }
}