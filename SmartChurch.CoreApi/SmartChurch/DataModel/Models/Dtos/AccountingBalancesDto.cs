using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class AccountingBalancesDto : ICommonDto
    {
        public int Id { get; set; }

        public decimal BankBalance { get; set; }
        public decimal ChurchBalance { get; set; }
    }
}