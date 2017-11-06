using Microsoft.AspNetCore.Identity;

namespace SuperUserWeb.Models
{
    // Add profile data for application users by adding properties to the UserAccount class
    public class UserAccount : IdentityUser
    {
        public string Bio { get; set; }
    }
}
