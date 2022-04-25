using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Software_Project.Models
{
    public partial class Department
    {
        [Key]
        public int DebtId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
