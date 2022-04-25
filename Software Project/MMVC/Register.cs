using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Software_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Software_Project.MMVC
{
    public class Register
    {
        [ValidateNever]

        public string Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Phone { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string? Gender { get; set; }
        [ValidateNever]
        [Required]
        public String UserName { get; set; }
        [Required]
        public string type { get; set; }

        [ValidateNever]
        public List<Disease> diesese { get; set; }

        [ValidateNever]

        public List<Medicine>? medicines{ get; set; }
        [ValidateNever]
        public Department dept { get; set; }
  
    }
}
