using CustomerInfo.Context;
using CustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerInfo.Controllers
{
    public class LoginController : Controller
    {
        private CustomerInforContext db = new CustomerInforContext();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = user.Password; // Hashing password
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var dbUser = db.Users.SingleOrDefault(u => u.Email == user.Email);
            if (dbUser != null)
            {
                // Successful login
                return RedirectToAction("Index", "Customer");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }
    }
}

