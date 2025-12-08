using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.DTOs
{
    public class AppointmentDto
    {
        public string Id { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
