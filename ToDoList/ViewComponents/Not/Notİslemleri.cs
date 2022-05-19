using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.ViewComponents.Not
{
    public class Notİslemleri : ViewComponent
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var userId = db.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();
            var userNotsData = db.Nots.Where(x => x.UserId == userId).ToList();
            return View(userNotsData);
        }
    }
}
