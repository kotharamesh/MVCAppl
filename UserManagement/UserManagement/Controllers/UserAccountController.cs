using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            using (UserDbContext db = new UserDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string action, UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                using (UserDbContext db = new UserDbContext())
                {
                    db.userAccount.Add(userAccount);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = userAccount.FirstName + " " + userAccount.LastName + " succesfully registerd.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                    if(usr != null)
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["UserName"] = usr.Username;
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or password is wrong");
                    }
                }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}