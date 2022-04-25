using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Project.MMVC;
using Software_Project.Models;
using System.Net.Mail;

namespace Software_Project.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly HospitalContext _context;

        public PatientController(HospitalContext context)
        {
            _context = context;
        }

        public IActionResult Index(string Id)
        {
            var doctor = _context.Doctors.Include(n=>n.Dept).Include(m=>m.User).FirstOrDefault(n => n.User.Id == Id);
            var model = new Register() { Email = doctor.User.Email, Gender = doctor.User.Gender, Name = doctor.User.Name, Phone = doctor.User.PhoneNumber, type = doctor.User.Type, Id = doctor.User.Id, UserName = new MailAddress(doctor.User.Email).User, dept = doctor.Dept };
            return View(model);
        }
        public IActionResult Book(/*[FromRoute]*/string Id,/*[FromQuery]*/ string UserName)
        {
            var check=_context.DoctorS_Peteints.Include(m=>m.Petient).FirstOrDefault(n => n.DoctorId == Id && n.Petient.User.UserName == UserName);
            if(check != null)
            {
                return View("Exist");
            }
            else
            {
                var patient = _context.Patients.FirstOrDefault(n => n.User.UserName == UserName);
                var doctor = _context.Doctors.FirstOrDefault(n => n.User.Id == Id);
                Doctor_Peteint doctorPeteint = new Doctor_Peteint { DoctorId = doctor.Id, PetientId = patient.Id };
                _context.DoctorS_Peteints.Add(doctorPeteint);
                _context.SaveChanges();
                return RedirectToAction("Profile", new { UserName });
            }
        }

        public async Task<IActionResult> Profile(string UserName)
        {
            var petientdoctor = _context.DoctorS_Peteints
                .Include(n => n.Petient).ThenInclude(k => k.Medicines).Include(m => m.Petient).ThenInclude(k => k.Diseases).Include(m => m.Petient).ThenInclude(k => k.User)
                .Include(m => m.Doctor).ThenInclude(c => c.User).Include(m => m.Doctor).ThenInclude(c => c.Dept)
                .Where(n => n.Petient.User.UserName == UserName).ToList();


            List<Doctor> doctors=new List<Doctor>(); ;
            foreach (var item in petientdoctor)
            {
                if (item != null)
                {
                    
                    doctors.Add(item.Doctor);
                }               
            }
            var item2 = petientdoctor.FirstOrDefault();
            doctor_patient_viewmodel model = new doctor_patient_viewmodel()
            {

                Diseases = item2.Petient.Diseases,
                Medicines = item2.Petient.Medicines,
                User = item2.Petient.User,
                Id = item2.PetientId,
                doctor = doctors.ToList()
            };
            return View(model);
        
        }

        public IActionResult Exist()
        {
            return View();
        }

    }
}
