using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CombinationBooks.Data;
using CombinationBooks.Models;
using CombinationBooks.ViewModels;

namespace CombinationBooks.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        public ActionResult ShowBooks()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var data = session.Query<Book>().ToList();
                return View(data);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<Author>().SingleOrDefault(u => u.UserName == loginVM.UserName);
                    TempData["AuthorId"] = user.Id;
                    if (user != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(loginVM.Password, user.Password))
                        {
                            FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                            //TempData["AuthorId"] = user.Id;
                            return RedirectToAction("Index", "AuthorDetails");
                        }
                    }
                    ModelState.AddModelError("", "UserNam/Password doesn't match");
                    return View();
                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Author author)
        {
            author.Password = BCrypt.Net.BCrypt.HashPassword(author.Password);
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    author.AuthorDetails.Author = author;
                    session.Save(author);
                    session.Flush();
                    txn.Commit();
                    return RedirectToAction("Login");
                }
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }

}
