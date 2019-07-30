using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class AppSettings : SiriusEntity
    {
        public string AppName { get; set; }
        public string AppLogo { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string City { get; set; }
    }
}