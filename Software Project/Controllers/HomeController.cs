using Microsoft.AspNetCore.Mvc;
using Software_Project.MMVC;
using Software_Project.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Software_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(HospitalContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var result = _context.Doctors.Include(n=>n.User).Include(n=>n.Dept).ToList();
            //var gender = result[0].Gender;
            return View(result);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register registered)
        {

            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser
                {
                    Name = registered.Name,
                    PhoneNumber = registered.Phone,
                    Email = registered.Email,
                    UserName = new MailAddress(registered.Email).User,
                    Type = registered.type,
                    Gender = registered.Gender

                };
                var result = await _userManager.CreateAsync(user, registered.Password);
            if (result.Succeeded)
            {
               
                if(user.Type.ToLower()=="Patient".ToLower())
                {
                    _context.Patients.Add(new Patient { Id = user.Id, UserId = user.Id });
                    _context.SaveChanges();
                    await _userManager.AddToRoleAsync(user, "Patient");
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Profile", "Home",user.UserName);

                }
                else if(user.Type.ToLower() == "Doctor".ToLower())
                {
                    _context.Doctors.Add(new Doctor { Id = user.Id, UserId = user.Id });
                    _context.SaveChanges();
                    await _userManager.AddToRoleAsync(user, "Doctor");
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Petient");
                }
                }
                else
                {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("ERROR", item.ToString());

                    }
                    return View(registered);

                }

            }
            else {
                return View(registered);
            }
            return View();
        }


        public async Task<IActionResult> logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            //IdentityUser user = new IdentityUser
            //{
            //    UserName = "yosefe@gmail.com",

            //};
            //var pass = "Yosef@12345";
            //var result2 = await _userManager.CreateAsync(user, pass);
            //if (result2.Succeeded)
            //{
            //    Admin admin = new Admin()
            //    {
            //        AdminId = 54169412,
            //        Eamil = "yosefe@gmail.com",
            //        Name = "Yosef",
            //        User = user
            //    };
            //    _context.Admins.Add(admin);
            //    _context.SaveChanges();
            //}
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(new MailAddress(login.Email).User, login.Password,true,false);
                if (result.Succeeded)
                {
                    var person = _userManager.Users.FirstOrDefault(n => n.Email == login.Email);

                    if (person.Type.ToLower() == "patient".ToLower())
                    {

                        return RedirectToAction("Profile", "Home",new { person.UserName });
                    }
                    else if (person.Type.ToLower() == "doctor".ToLower())
                    {

                        return RedirectToAction("Petient", "Home", person.Id);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }
                }
                else
                {

                    ModelState.AddModelError("ERROR", "Your Email or Password is wrong");
                    return View(login);
                }
            }
            else
            {
                return View(login);
            }
            return View();
        }
        public async Task<IActionResult> Petient(string Id)
        {
            var DoctorPeteint = _context.DoctorS_Peteints.Where(n => n.DoctorId == Id).ToList();
            return View(DoctorPeteint);
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }

    }
}