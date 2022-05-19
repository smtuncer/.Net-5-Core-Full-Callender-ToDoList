using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class EventController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            var userEventsData = db.Events.Where(x => x.UserId == userId).ToList();
            return View(userEventsData);
        }
        public IActionResult EtkinlikGetir()
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            var userEventsData = db.Events.Where(x => x.UserId == userId).ToList();
            return new JsonResult(userEventsData);
        }

        [HttpGet]
        public IActionResult EventEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EventEkle(Events p)
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            p.UserId = userId;
            db.Events.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Event");
        }
        public IActionResult EventSil(Events p)
        {
            db.Events.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Event");
        }
        [HttpGet]
        public IActionResult EventGüncelle(int id)
        {
            var eventData = db.Events.FirstOrDefault(i => i.id == id);
            return View(eventData);
        }
        [HttpPost]
        public IActionResult EventGüncelle(Events p)
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            p.UserId = userId;
            db.Events.Update(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Event");
        }

    }
}