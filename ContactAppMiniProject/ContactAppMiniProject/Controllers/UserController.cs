using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ContactAppMiniProject.Data;
using ContactAppMiniProject.Models;
using ContactAppMiniProject.ViewModels;

namespace ContactAppMiniProject.Controllers
{
    [Authorize]  // Ensures user must be authenticated to access any action in this controller
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM loginVM)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Query<User>().SingleOrDefault(u => u.UserName == loginVM.UserName);
                TempData["UserId"] = user.Id;
                //HttpCookie cookie = new HttpCookie("myCookie");
                //cookie.Value = user.Id.ToString();
                //cookie.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(cookie);
                if (user != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, user.Password))
                {
                    if (user.IsActive == true)
                    {
                        FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                        return user.IsAdmin ? RedirectToAction("AdminDashboard") : RedirectToAction("UserDashboard", "Contact");
                    }
                    ModelState.AddModelError("", "User is Inactive. Contact System Admin");
                }
                else
                {
                    ModelState.AddModelError("", "UserName/Password doesn't match");
                }
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult AdminDashboard()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var users = session.Query<User>().Where(u => !u.IsAdmin).ToList();
                return View(users);
            }
        }

        [HttpPost]
        public ActionResult UpdateIsActiveStatus(Guid userId, bool isActive)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<User>().SingleOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsActive = isActive;
                        session.Update(user);
                        txn.Commit();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, message = "User not found" });
                }
            }
        }

        [HttpPost]
        public ActionResult UpdateIsAdminStatus(Guid userId, bool isAdmin)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<User>().SingleOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsAdmin = isAdmin;
                        session.Update(user);
                        txn.Commit();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, message = "User not found" });
                }
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult ViewAdmins()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var admins = session.Query<User>().Where(u => u.IsAdmin).ToList();
                return View(admins);  // Displays list of admin users
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    user.IsActive = true;
                    user.Role.User = user;
                    user.Role.RoleName = user.IsAdmin ? "admin" : "staff";
                    session.Save(user);
                    txn.Commit();
                    return RedirectToAction("AdminDashboard");
                }
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Get<User>(id);
                if (user == null) return HttpNotFound();
                return View(user);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var existingUser = session.Get<User>(user.Id);
                    if (existingUser == null) return HttpNotFound();

                    existingUser.UserName = user.UserName;
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.IsActive = user.IsActive;
                    session.Update(existingUser);
                    txn.Commit();
                    return RedirectToAction("AdminDashboard");
                }
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Get<User>(id);
                if (user == null) return HttpNotFound();
                return View(user);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Get<User>(id);
                    if (user != null)
                    {
                        user.IsActive = false;
                        session.Update(user);
                        txn.Commit();
                    }
                    return RedirectToAction("AdminDashboard");
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