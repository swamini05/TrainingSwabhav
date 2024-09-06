using System.Web.Mvc;
using SessionDemo.Filters;

namespace SessionDemo.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                Session["User"] = username;
                return RedirectToAction("Welcome");
            }
            ViewBag.Message = "Invalid login attempt";
            return View();
        }

        [SessionTimeout]
        public ActionResult Welcome()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = Session["User"].ToString();
                return View();
            }
            TempData["TimeoutMessage"] = "Session expired. Please log in again.";
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [SessionTimeout]
        public ActionResult GetDetails()
        {
            return View();
        }
    }
}