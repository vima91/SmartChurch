using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class IncomeDto : ICommonDto
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}