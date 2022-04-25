using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Project.Models
{
    public partial class Admin
    {
        public string Id { get; set; }
        [ForeignKey("User")]
        public String UserId { get; set; }
        public ApplicationUser User{ get; set; }
    }
}
