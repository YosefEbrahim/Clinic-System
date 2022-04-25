namespace Software_Project.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MediceneName{ get; set; }
        public string? PatientId { get; set; }
        public virtual Patient? Patient
        {
            get; set;
        }
    }
}
