using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ServiceTypeDto : CommonNameDto
    {
        public string Description { get; set; }
        public bool IsNotLinkableToPersons { get; set; }
    }
}