using Microsoft.AspNetCore.Identity;

namespace ClinicalManagement.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ClinicalManagementUser : IdentityUser
    {
        public bool EnanbleNotification { get; set; } = false;
        public string Initials { get; set; }
    }
}
