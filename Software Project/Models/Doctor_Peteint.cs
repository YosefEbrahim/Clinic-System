using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Software_Project.Models
{
    public partial class Doctor_Peteint
    {
        [Key]
        public int Id { get; set; }
        public string? DoctorId { get; set; }
        public string? PetientId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Petient { get; set; }

    }
}
