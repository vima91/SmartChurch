using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class AppUserDto : ICommonDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}