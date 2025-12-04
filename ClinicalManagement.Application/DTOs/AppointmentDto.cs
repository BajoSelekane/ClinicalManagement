using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.DTOs
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Patient? patients { get; set; }
        public Guid PatientId { get; set; }
        public Doctor? doctors { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
        public Clinic? clinic { get; set; }
        //public Guid TimeSlotId { get; set; }
        public TimeSlot? timeSlot { get; set; }
        public string? Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; } = false;

    }
    public class CreateAppointmentDto
    {
        
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
        public string? Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; } = false;
    }
}

//public Patient? patients { get; set; }
//public Clinic? clinic { get; set; }
//public Guid TimeSlotId { get; set; }
//public TimeSlot? timeSlot { get; set; }
//public Doctor? doctors { get; set; }