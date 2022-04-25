namespace Software_Project.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime appintment { get; set; }
        public string? PatientId { get; set; }
        public virtual Patient? Patient
        {
            get; set;
        }
    
    }
}
