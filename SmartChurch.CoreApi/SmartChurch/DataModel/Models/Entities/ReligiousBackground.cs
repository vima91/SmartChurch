﻿using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Entities
{
    public class ReligiousBackground : SiriusDeletableEntity
    {
        [Required]
        public string Name { get; set; }
    }
}