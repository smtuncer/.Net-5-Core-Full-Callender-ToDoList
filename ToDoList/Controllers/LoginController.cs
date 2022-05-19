using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User p)
        {
            var dataValue = db.Users.FirstOrDefault(i => i.Email == p.Email && i.Password == p.Password);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", p.Email);
//    return RedirectToAction("Index", "Home");
//}
//else
//{
//    return View();
//}