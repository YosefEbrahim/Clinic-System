using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Project.Models
{
    public partial class Patient 
    {
        public string Id { get; set; }
        public virtual List<Disease>  Diseases{ get; set; }
        public virtual List<Medicine>? Medicines { get; set; }
        [ForeignKey("User")]
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
