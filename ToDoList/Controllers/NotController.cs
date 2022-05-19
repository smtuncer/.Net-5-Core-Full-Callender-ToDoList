using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class NotController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var notData = db.Nots.FirstOrDefault(i => i.NotId == id);
            return View(notData);
        }
        public IActionResult NotSil(Not p)
        {
            db.Nots.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }
        public IActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NotEkle(Not p)
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            p.UserId = userId;
            db.Nots.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult NotGüncelle(int id)
        {
            var notData = db.Nots.FirstOrDefault(i => i.NotId == id);
            return View(notData);
        }
        [HttpPost]
        public IActionResult NotGüncelle(Not d)
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            d.UserId = userId;
            db.Nots.Update(d);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
