

namespace ClinicalManagement.Domain.Entities
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
}
