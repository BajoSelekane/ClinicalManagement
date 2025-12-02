namespace ClinicalManagement.Domain.Entities
{
    public class TimeSlot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Doctor? doctors  { get; set; }
        public Guid DoctorId { get; set; }
        public Clinic? clinic { get; set; }
        public Guid ClinicId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; } =false;
        
    }
}
