using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ExpenseDto : ICommonDto
    {
        public int Id { get; set; }

        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
    }
}