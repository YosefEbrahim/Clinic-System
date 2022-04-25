namespace Software_Project.Models
{
    public class Disease
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public string? PatientId { get; set; }
        public virtual Patient? Patient
        {
            get; set;
        }
    }

}
