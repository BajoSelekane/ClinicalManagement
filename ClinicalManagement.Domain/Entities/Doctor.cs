namespace ClinicalManagement.Domain.Entities
{
    public class Doctor: BaseEntity
    {
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public string? Email { get; set; }
       
    }
}
