using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicalManagement.Application.ViewModels
{
    public class TimeSlotViewModel
    {
        public string? DoctorId { get; set; }
        public string? ClinicId { get; set; }
        public DateTime DayOfWeek { get; set; }
        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End time is required")]
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; } = false;
        public Doctor? Doctors { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
