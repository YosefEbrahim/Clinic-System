using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Project.MMVC;
using Software_Project.Models;
using System.Net.Mail;

namespace Software_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HospitalContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(HospitalContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult AllDoctor()
        {
            var dctors = _context.Doctors.Include(n => n.User).Include(n => n.Dept).ToList();
            return View(dctors);
        }
        public IActionResult AllPetient()
        {
            var patients = _context.Patients.Include(n => n.User).Include(n => n.Medicines).ToList();
            return View(patients);
        }
        public IActionResult Edit(string id)
        {
            var doctor = _context.Doctors.Include(n => n.User).Include(n => n.Dept).FirstOrDefault(n => n.User.Id==id);
            var patient = _context.Patients.Include(n => n.User).Include(n => n.Medicines).FirstOrDefault(n => n.User.Id == id);


            if (doctor != null)
            {
                var model = new Register() { Email = doctor.User.Email, Gender = doctor.User.Gender, Name = doctor.User.Name, Phone = doctor.User.PhoneNumber,type=doctor.User.Type,Id=doctor.User.Id, UserName = new MailAddress(doctor.User.Email).User,dept=doctor.Dept };
                return View(model);
            }
            else if (patient != null)
            {
                var model = new Register() { Email = patient.User.Email, Gender = patient.User.Gender, Name = patient.User.Name, Phone = patient.User.PhoneNumber,medicines=patient.Medicines.ToList(),diesese=patient.Diseases.ToList(), type = patient.User.Type, Id = patient.User.Id , UserName = new MailAddress(patient.User.Email).User };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Register register)
        {


            if (register.type.ToLower() == "Doctor".ToLower())
            {
                var doctor=_context.Doctors.Include(n => n.User).Include(n => n.Dept).FirstOrDefault(m => m.Id == register.Id);
                doctor.User.Gender = register.Gender;
                doctor.User.Email = register.Email;
                doctor.User.UserName = new MailAddress(register.Email).User;
                doctor.User.Name = register.Name;
                doctor.User.PhoneNumber = register.Phone;
                doctor.Dept.Name = register.dept.Name;                       
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return RedirectToAction("AllDoctor");
            }
            else
            {
                var patient = _context.Patients.Include(n=>n.User).Include(n => n.Medicines).FirstOrDefault(m=>m.Id==register.Id);
                patient.User.Gender = register.Gender;
                patient.User.Email = register.Email;
                patient.User.UserName = new MailAddress(register.Email).User;
                patient.User.Name = register.Name;
                patient.User.PhoneNumber = register.Phone;
                for (int i = 0; i < register.diesese.Count; i++)
                {
                    patient.Diseases[i] = register.diesese[i];
                }
                for (int i = 0; i < register.medicines.Count; i++)
                {
                    patient.Medicines[i] = register.medicines[i];
                }
                _context.Patients.Update(patient);
                _context.SaveChanges();
                return RedirectToAction("AllPetient");
            }
            return View();
        }

        public IActionResult Delete(string Id)
        {
            var item = _context.Patients.Include(n=>n.User).Include(n => n.Medicines).FirstOrDefault(m => m.Id == Id);
            var item2 = _context.Doctors.Include(n=>n.User).FirstOrDefault(m => m.Id == Id);
            if (item != null)
            {
                var model = new Register() { Email = item.User.Email, Gender = item.User.Gender, Name = item.User.Name, Phone = item.User.PhoneNumber, medicines = item.Medicines.ToList(), diesese = item.Diseases.ToList(), type = item.User.Type, Id = item.User.Id, UserName = new MailAddress(item.User.Email).User };
                return View(model);
            }
            else if(item2 != null)
            {
                var model = new Register() { Email = item2.User.Email, Gender = item2.User.Gender, Name = item2.User.Name, Phone = item2.User.PhoneNumber, type = item2.User.Type, Id = item2.User.Id, UserName = new MailAddress(item2.User.Email).User };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("ERROR", "Element Not Found");
                return View("Error");
            }
           
            return View();
        }
        public IActionResult DeletePost(String Id)
        {
            var item = _context.Users.FirstOrDefault(n => n.Id == Id);
            //if (item.Type.ToLower() == "Doctor".ToLower())
            //{

            //    _context.Doctors.Remove(item);
            //    _context.SaveChanges();
            //}
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                _userManager.DeleteAsync(item);
                if(item.Type.ToLower() == "Doctor".ToLower())
                {
                return RedirectToAction("AllDoctor");
                }
                else
                {
                    return RedirectToAction("AllPetient");
                }

            }
            return View();

        }
        public async Task<IActionResult> Details(string Id)
        {
            var doctor = _context.Doctors.Include(n => n.User).FirstOrDefault(n => n.User.Id == Id);
            var patient = _context.Patients.Include(n => n.User).Include(n => n.Medicines).FirstOrDefault(n => n.User.Id == Id);
            if (doctor != null)
            {
                var model = new Register() { Email = doctor.User.Email, Gender = doctor.User.Gender, Name = doctor.User.Name, Phone = doctor.User.PhoneNumber, type = doctor.User.Type, Id = doctor.User.Id, UserName = new MailAddress(doctor.User.Email).User, dept = doctor.Dept };
                return View(model);
            }
            else if (patient != null)
            {
                var model = new Register() { Email = patient.User.Email, Gender = patient.User.Gender, Name = patient.User.Name, Phone = patient.User.PhoneNumber, medicines = patient.Medicines.ToList(), diesese = patient.Diseases.ToList(), type = patient.User.Type, Id = patient.User.Id, UserName = new MailAddress(patient.User.Email).User };
                return View(model);
            }
            return View();
        }
        public async Task<IActionResult> AddMedicine(string Id)
        {
            var item = _userManager.Users.FirstOrDefault(n => n.Id == Id);
            return View(new CommonProp { Id=Id,Name=item.Name});
        }
        [HttpPost]
        public async Task<IActionResult> AddMedicine(CommonProp register)
        {
            var item = _context.Users.FirstOrDefault(n => n.Id == register.Id);
            Medicine n = new Medicine { MediceneName = register.SingleMedicine, PatientId = item.Id };
            _context.Medicines.Add(n);
            _context.SaveChanges();
            TempData["msg"] = "Item is added Success";
            return RedirectToAction("AddMedicine", "Admin",new { register.Id });
        }


        public IActionResult DeleteMidecine(int Id,string PatientId)
        {
            var item = _context.Medicines.FirstOrDefault(n => n.Id == Id);
            CommonProp n = new CommonProp { Id = PatientId };
            if (item != null)
            {
                _context.Medicines.Remove(item);
                _context.SaveChanges();
                TempData["msgDel"] = "You have Delete item Success";
                return RedirectToAction("Delete", "Admin",new { n.Id });
            }
            return View();
        }









    }
}
