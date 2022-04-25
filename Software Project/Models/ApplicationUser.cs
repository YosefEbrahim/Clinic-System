using Microsoft.AspNetCore.Identity;

namespace Software_Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public String Gender { get; set; }
        public String Type { get; set; }
    }
}
