using System;
using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class Expense : SiriusDeletableEntity
    {
        [Required]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Comment { get; set; }

        [Required]
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}