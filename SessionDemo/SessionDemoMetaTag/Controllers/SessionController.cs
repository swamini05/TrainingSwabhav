using System.Web.Mvc;

namespace SessionDemo.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Hard-coded user validation for POC
            if (username == "admin" && password == "password")
            {
                Session["User"] = username;
                return RedirectToAction("Welcome");
            }
            ViewBag.Message = "Invalid login attempt";
            return View();
        }

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
            Session.Clear(); // Clear all session data
            return RedirectToAction("Login");
        }
    }
}