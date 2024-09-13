using System;
using System.Web;
using System.Web.Mvc;
using CookieDemo.Data;
using CookieDemo.Models;

namespace CookieDemo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.QueryOver<User>()
                                  .Where(x => x.Username == username)
                .SingleOrDefault();

                if (user != null)
                {
                    string token = Guid.NewGuid().ToString();

                    HttpCookie cookie = new HttpCookie("UserCookie");
                    cookie.Values["Username"] = user.Username;
                    cookie.Values["UserId"] = user.Id.ToString();
                    cookie.Values["Token"] = token;
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index");
                }

                ViewBag.Message = "Invalid login attempt.";
                return View();
            }
        }

        public ActionResult Welcome()
        {
            HttpCookie cookie = Request.Cookies["UserCookie"];
            if (cookie != null)
            {
                ViewBag.Username = cookie.Values["Username"];
                return View();
            }

            return RedirectToAction("Login");
        }

        public ActionResult CheckCookie()
        {
            HttpCookie cookie = Request.Cookies["UserCookie"];
            if (cookie != null && cookie.Values["Token"] != null)
            {
                return RedirectToAction("Welcome");
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            if (Request.Cookies["UserCookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserCookie")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}