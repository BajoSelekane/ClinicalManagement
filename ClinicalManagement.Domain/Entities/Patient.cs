namespace ClinicalManagement.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public required long IDNumber { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Description { get; set; }

    }
}
