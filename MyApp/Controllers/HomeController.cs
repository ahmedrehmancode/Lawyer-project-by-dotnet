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
        public IActionResult Signup()
        {
            var lawyer = _context.RegisterLawyers.ToList();
            return View(lawyer);
        }
        public IActionResult Login()
        {
            return View();

        }


    }
}
