

namespace ClinicalManagement.Domain.Entities
{
    public class Appointment :BaseEntity
    {
        public required string PatientId { get; set; }    
        public string? DoctorId { get; set; }
        public string? ClinicId { get; set; }     
        public string? Phone { get; set; }
        public DateTime AppointmentDate { get; set; } 
        public DateTime EndTime { get; set; }
        public Patient? patients { get; set; }
        public Doctor? doctors { get; set; }
        public Clinic? clinic { get; set; }
        public TimeSlot? timeSlot { get; set; }
        //public bool Status { get; set; } = false;
        //public Guid TimeSlotId { get; set; }

    }
}
