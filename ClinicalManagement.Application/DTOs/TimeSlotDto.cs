using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.DTOs
{
    public class TimeSlotDto
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
