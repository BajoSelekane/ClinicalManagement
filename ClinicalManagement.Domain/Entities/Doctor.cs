namespace ClinicalManagement.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public string? Email { get; set; }
       
    }
}
