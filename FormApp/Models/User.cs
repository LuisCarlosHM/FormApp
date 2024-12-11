using Microsoft.AspNetCore.Identity;
using System;

namespace FormApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
