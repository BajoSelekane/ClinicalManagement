namespace ClinicalManagement.Domain.Entities
{
    public class TimeSlot :BaseEntity
    {
    
        
        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; } =false;
        public Doctor? doctors { get; set; }
        public Clinic? clinic { get; set; }

    }
}
