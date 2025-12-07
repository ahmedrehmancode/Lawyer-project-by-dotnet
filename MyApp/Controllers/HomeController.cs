using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
//using MyApp.Model;

using MyApp.Data;
using MyApp.Model;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context;


        public HomeController(MyDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Client client)
        {
            _context.T_Students.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Client");
        }



        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Blog()
        {
            //ViewBag.hidebutton = true;
            return View();
        }

        public IActionResult Client()
        {
            var std = _context.T_Students.ToList();
            return View(std);
        }
        public IActionResult Delete(int id)
        {
            var del = _context.T_Students.Find(id);
            _context.T_Students.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("Client");
        }

        public IActionResult Edit(int id)
        {
            var std = _context.T_Students.Find(id);
            return View(std);

        }
        [HttpPost]
        public IActionResult Edit(int id, Client updated)
        {

            //return View();
            //var del = _context.T_Students.Find(id);
            _context.T_Students.Update(updated);
            _context.SaveChanges();
            return RedirectToAction("Client");
        }


        //register lawyer
        public IActionResult RegisterLawyer()
        {
            return View();

        }
        [HttpPost]
        public IActionResult RegisterLawyer(LawyerRegistration lawyer)
        {
            _context.RegisterLawyers.Add(lawyer);
            _context.SaveChanges();
            return View("index");

        }
        [HttpPost]
        public IActionResult signup(signup signin)
        {
            _context.signupdetail.Add(signin);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Signup()
        {
            return View();


        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(string uemail, string upass)
        {
            var idintify = _context.signupdetail.FirstOrDefault(u => u.Email == uemail);
            if (idintify != null && idintify.Password == upass)
            {
                HttpContext.Session.SetString("Name", idintify.Name);
                return RedirectToAction("Dashboard");
            }
            else
            {

                //return RedirectToAction("dashboard");


                ViewBag.error = "Invalid email or password";
                return View();
            }

        }

        public IActionResult Dashboard()
        {
            ViewBag.showbutton = true;
            ViewBag.hidebutton = true;
            if (HttpContext.Session.GetString("Name") != null)
            {
                ViewBag.name = HttpContext.Session.GetString("Name");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
