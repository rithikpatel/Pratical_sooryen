using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pratical_Rithik.Interface;
using Pratical_Rithik.Repository;
using Pratical_Rithik.Models;

namespace Pratical_Rithik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private readonly ILoginRepository loginRepo;

        public LoginController()
        {
            loginRepo = new LoginRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var IsValid = loginRepo.Login(login);
                if (IsValid)
                {
                    return RedirectToAction("Index", "Note");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username and Password.");
                }
            }
            return View(login);
        }

        public ActionResult LogOut()
        {
            loginRepo.LogOut();
            return View("Login");
        }
    }
}