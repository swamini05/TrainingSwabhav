using System.Web.Mvc;
using HashingDemo.Data;
using HashingDemo.Models;

namespace HashingDemo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string username, string password)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                var newUser = new User
                {
                    Username = username,
                    Password = hashedPassword
                };

                session.Save(newUser);
                session.Flush();
            }
            return RedirectToAction("Login");
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
                var user = session.QueryOver<User>().Where(u => u.Username == username).SingleOrDefault();

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}