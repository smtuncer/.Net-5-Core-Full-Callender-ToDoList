using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User p)
        {
            db.Users.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
