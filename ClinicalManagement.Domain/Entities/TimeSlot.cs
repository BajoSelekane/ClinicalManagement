namespace ClinicalManagement.Domain.Entities
{
    public class TimeSlot :BaseEntity
    {
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; } =false;
        public Doctor? Doctors { get; set; }
        public Clinic? Clinic { get; set; }

    }
}
