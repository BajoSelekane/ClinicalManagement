using ClinicalManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicalManagement.Infrastructure.Data
{
  public class ClinicalContextDB :IdentityDbContext<IdentityUser>
    //public class ClinicalContextDB(DbContextOptions options) : DbContext(options)
    {
        public ClinicalContextDB(DbContextOptions<ClinicalContextDB> options) : base(options) 
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Poctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TimeSlot> Timeslots { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<LoginModal> LoginModals { get; set; }
        public DbSet<RegisterModal> RegisterModals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
        }

    

       
    }
}
//seed Patients data
//modelBuilder.Entity<Patient>().HasData(
//     new Patient { Id = Guid.Parse("9e609d11-aea4-46b1-ba7e-a18fc5db34a1"), DateOfBirth = new DateTime(2000, 1, 15), Description = "Health", Email = "Thabo@yahoo.com", IDNumber = 8812055058081L, Name = "Thabo", PhoneNumber = "27684324014" },
//     new Patient { Id = Guid.Parse("8e609d11-bea4-46b1-ba7e-a18fc5db34a2"), DateOfBirth = new DateTime(1990, 07, 29), Description = "Consultation", Email = "Oupa@yahoo.com", IDNumber = 9602150570815L, Name = "Oupa", PhoneNumber = "27731219291" },
//     new Patient { Id = Guid.Parse("7e609d11-cea4-46b1-ba7e-a18fc5db34a3"), DateOfBirth = new DateTime(1998, 09, 12), Description = "General", Email = "Winnie@yahoo.com", IDNumber = 8508250570815L, Name = "Winnie", PhoneNumber = "27731218587" }

//    );

//seed Doctors data
//modelBuilder.Entity<Doctor>().HasData(
//   new Doctor { Id = Guid.Parse("1e609d11-bea4-46b1-ba7e-a18fc5db34aa"), Name = "DR Mathew ", Specialty = "General", Email = "Mathew@Medicare.com" },
//   new Doctor { Id = Guid.Parse("2e609d11-bea4-46b1-ba7e-a18fc5db34ab"), Name = "DR Selekon ", Specialty = "Gynecologist", Email = "Selekon@Medicare.com" },
//   new Doctor { Id = Guid.Parse("3e609d11-bea4-46b1-ba7e-a18fc5db34ac"), Name = "DR Zeelensky ", Specialty = "Heart-Surgeon", Email = "Zeelensky@Gov.com" }
//   );

//var clinicId = Guid.Parse("6e609d11-bea4-46b1-ba7e-a18fc5db34a6");
//modelBuilder.Entity<Clinic>().HasData(new Clinic { Id = clinicId, Name = "Central PHC", Address = "123 Main St" });
//// Create timeslots for next 3 days
//var slots = new List<TimeSlot>();
//for (int d = 0; d < 3; d++)
//{
//    var date = DateTime.UtcNow.Date.AddDays(d).AddHours(8);
//    for (int i = 0; i < 8; i++)
//    {
//        slots.Add(new TimeSlot { Id = Guid.Parse("5e609d11-bea4-46b1-ba7e-a18fc5db34az"), ClinicId = clinicId, StartTime = date.AddHours(i), EndTime = date.AddHours(i + 1), IsAvailable = false });
//    }
//}