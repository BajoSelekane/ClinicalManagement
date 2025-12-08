using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ClinicalManagementUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ClinicalManagementUser>(entity =>
            {
                entity.Property(e => e.EnanbleNotification).HasDefaultValue(true);
                entity.Property(e => e.Initials).HasMaxLength(5);
            });

            builder.HasDefaultSchema("identity");
        }
    }
}
