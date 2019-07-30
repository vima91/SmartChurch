using System;
using SmartChurch.DataModel.Models.Core;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class AttendanceDto : ICommonDto
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public DateTime DateOfEvent { get; set; }
        public int PersonId { get; set; }
        public string Comment { get; set; }
    }
}