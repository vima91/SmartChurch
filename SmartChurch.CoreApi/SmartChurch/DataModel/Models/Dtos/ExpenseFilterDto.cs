using System;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class ExpenseFilterDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}