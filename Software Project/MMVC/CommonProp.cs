using Software_Project.Models;

namespace Software_Project.MMVC
{
    public class CommonProp
    {
        public string Id { get; set; }

        public string Name { get; set; } = null!;
        

        public string? Email { get; set; }


        public string? Phone { get; set; }


        public string Password { get; set; }


        public string? Gender { get; set; }

        public String UserName { get; set; }
        public string type { get; set; }

        public string diesese { get; set; }


        public List<Medicine> medicines { get; set; }

        public Department dept { get; set; }
        public string SingleMedicine { get; set; }
    }
}
