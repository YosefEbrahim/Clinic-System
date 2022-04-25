using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Project.Models
{
    public partial class Doctor
    {
        public string Id { get; set; }
        public List<Appointments> Appointments{ get; set; }
        public int? DeptId { get; set; }
        public virtual Department? Dept { get; set; }
        [ForeignKey("User")]
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
