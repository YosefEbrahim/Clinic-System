using Software_Project.Models;

namespace Software_Project.MMVC
{
    public  class doctor_patient_viewmodel
    {
        public string Id { get; set; }
        public virtual List<Disease> Diseases { get; set; }
        public virtual List<Medicine>? Medicines { get; set; }
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Doctor> doctor { get; set; }


    }
}
