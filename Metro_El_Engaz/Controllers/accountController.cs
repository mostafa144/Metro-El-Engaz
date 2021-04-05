using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metro_El_Engaz.Models;

namespace Metro_El_Engaz.Controllers
{
    public class accountController : Controller
    {
        Entities1 db = new Entities1();
        // GET: account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {

            var result = db.Users.Where(m => m.Username == user.Username && m.Password == user.Password).FirstOrDefault();

            if (result != null)

            {

                return RedirectToAction("Index", "Home");

            }

            else

            {

                ViewBag.Message = string.Format("UserName and Password is incorrect");

                return View();

            }
        }
        public ActionResult Rgister()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Rgister(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return View();
        }
    }
}