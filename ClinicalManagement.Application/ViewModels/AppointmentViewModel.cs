using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicalManagement.Application.ViewModels
{
    public class AppointmentViewModel
    {
        [Required(ErrorMessage = "Patient is required")]
        public string PatientId { get; set; } = string.Empty;

        public string? DoctorId { get; set; }

        public string? ClinicId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "End time is required")]
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(1);
    }
}
