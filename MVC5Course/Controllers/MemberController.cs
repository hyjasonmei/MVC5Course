using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class MemberController : Controller
    {
        [Authorize]
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model )
        {
            if (CheckLogin(model.Email))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Email, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("PassWord", "password error");
            return View();
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        private bool CheckLogin(string p)
        {
            return (p == "aaa@aa.aa");
            throw new NotImplementedException();
        }
    }
}