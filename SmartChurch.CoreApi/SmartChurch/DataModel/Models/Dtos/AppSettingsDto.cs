using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class AppSettingsDto : ICommonDto
    {
        public int Id
        {
            get => 1;
            set { }
        }

        public string AppName { get; set; }
        public string AppLogo { get; set; }

        public int CountryId { get; set; }
        public string City { get; set; }
    }
}