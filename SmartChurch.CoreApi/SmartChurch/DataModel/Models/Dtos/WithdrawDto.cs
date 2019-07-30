using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class WithdrawDto : ICommonDto
    {
        public int Id { get; set; }

        public decimal WithdrawalAmount { get; set; }
    }
}