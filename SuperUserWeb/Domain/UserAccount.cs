using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SuperUserWeb.Domain
{
    // Add profile data for application users by adding properties to the UserAccount class
    public class UserAccount : IdentityUser
    {
        public string Bio { get; set; }

        public IList<Booking> Bookings { get; set; }
    }
}
