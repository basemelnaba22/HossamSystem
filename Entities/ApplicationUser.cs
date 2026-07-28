using Microsoft.AspNetCore.Identity;

namespace HossamSystem.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? ProfileId { get; set; }
    }
}
