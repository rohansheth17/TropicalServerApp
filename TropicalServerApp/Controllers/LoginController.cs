using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServer.BLL;

namespace TropicalServerApp.Controllers
{
    public class LoginController : Controller
    {
        // static user object 
        // GET: Login

        public ActionResult Joole()
        {
            return View();
        }
        public ActionResult Login()
        {
            /*
            if ((string)Session["username"] == "sessionon")
            {
                return RedirectToAction("Orders", "Product");
            }*/
            
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult ForgotUsername()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginVerify(string username, string password)
        {
            
        
            ReportsBLL rbll = new ReportsBLL();
            
            if (rbll.VerifyLogin(username, password))
            {
                Session["username"] = "sessionon";
                return RedirectToAction("Orders","Product");
            }
            return RedirectToAction("Error","Login");
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}