using System;
using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class Transaction : SiriusDeletableEntity
    {
        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        [Required]
        public int TransactionSourceTypeId { get; set; }
        public virtual TransactionSourceType TransactionSourceType { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}