using Microsoft.AspNetCore.Identity;

namespace MpiSchedule.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public bool Manager { get; set; }
}