using System;
using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class Income : SiriusDeletableEntity
    {
        [Required]
        public string ReceiptNumber { get; set; }

        [Required]
        public DateTime ReceiptDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
