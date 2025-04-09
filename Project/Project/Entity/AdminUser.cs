using Microsoft.AspNetCore.Identity;

namespace Project.Entity
{
    public class AdminUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}