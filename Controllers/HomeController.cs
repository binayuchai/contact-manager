using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using contactmanager.Models;
using contactmanager.Data;

namespace contactmanager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactManagerContext _db;

        public HomeController(ILogger<HomeController> logger, ContactManagerContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ContactViewModel model = new ContactViewModel();
            model.Persons = _db.Persons.ToList();
            return View(model);
        }
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(string first_name, string middle_name, string last_name, string gender, DateTime dob)
        {
            Person p = new Person();
            //Category c = new Category();
            p.FirstName = first_name;
            p.MiddleName = middle_name;
            p.LastName= last_name;
            p.Gender = gender;
            p.Dob = dob;
            _db.Persons.Add(p);
            _db.SaveChanges();
            ViewBag.Message =  "Success";
            return View();
        }

        public IActionResult EditContact(int id)
        {
            //Lamda Expression in C# (LINQ)
            Person p = _db.Persons.Where(x=> x.PersonID == id).FirstOrDefault();
            ContactViewModel model = new ContactViewModel();
            model.Person = p;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditContact(int id, string first_name, string middle_name, string last_name, string gender, DateTime dob)
        {
            Person p =  _db.Persons.Where(x=> x.PersonID == id).FirstOrDefault();
            //Category c = new Category();
            p.FirstName = first_name;
            p.MiddleName = middle_name;
            p.LastName= last_name;
            _db.SaveChanges();
            ViewBag.Message =  "Success";

            ContactViewModel model = new ContactViewModel();
            model.Person = p;
            return View(model);
        }
        // delete existing ID
        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            Person p = _db.Persons.Where(x=> x.PersonID == id).FirstOrDefault();
            ContactViewModel model = new ContactViewModel();
            model.Person = p;
            return View(model);
          
        }
        [HttpPost]
        public IActionResult DeleteContactConfirm(int id)
        {
            Person p =  _db.Persons.Where(x=> x.PersonID == id).FirstOrDefault();
            _db.Persons.Remove(p);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
         
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
