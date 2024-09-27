using System;
using System.Linq;
using System.Web.Mvc;
using ContactAppMiniProject.Data;
using ContactAppMiniProject.Models;

namespace ContactAppMiniProject.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult UserDashboard(Guid? id)
        {
            if (id != null)
            {
                TempData["UserId"] = id;
                return View();
            }
            return View();
        }
        public ActionResult GetAllContacts()
        {
            //HttpCookie userId = Request.Cookies["myCookie"];
            //Guid userId;

            var userId = (Guid)TempData.Peek("UserId");
            using (var session = NHibernateHelper.CreateSession())
            {
                var contacts = session.Query<Contact>().Where(c => c.User.Id == userId).ToList();
                bool isAdmin = User.IsInRole("admin");


                if (contacts.Count > 0)
                {
                    //return Json(contacts.Select(c => new
                    //{
                    //    c.Id,
                    //    c.FirstName,
                    //    c.LastName,
                    //    c.IsActive
                    //}), JsonRequestBehavior.AllowGet);
                    return Json(new
                    {
                        contacts = contacts.Select(c => new
                        {
                            c.Id,
                            c.FirstName,
                            c.LastName,
                            c.IsActive
                        }),
                        isAdmin
                    }, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(500);
            }
        }

        //public ActionResult GetAllContacts()
        //{
        //    // Retrieve the current user's ID from TempData
        //    var userId = (Guid)TempData.Peek("UserId");

        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        // Fetch contacts for the current user
        //        var contacts = session.Query<Contact>()
        //                              .Where(c => c.User.Id == userId)
        //                              .ToList();

        //        // Check if the current user is an admin
        //        bool isAdmin = User.IsInRole("admin");

        //        // If contacts are found, return them along with the isAdmin flag
        //        if (contacts.Count > 0)
        //        {
        //            var contactList = contacts.Select(c => new
        //            {
        //                c.Id,
        //                c.FirstName,
        //                c.LastName,
        //                c.IsActive
        //            }).ToList();

        //            return Json(new { contacts = contactList, isAdmin }, JsonRequestBehavior.AllowGet);
        //        }

        //        // Return a 500 status code if no contacts are found
        //        return new HttpStatusCodeResult(500);
        //    }
        //}

        [HttpPost]
        public ActionResult UpdateStatus(int id, bool isActive)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var contact = session.Get<Contact>(id);
                if (contact != null)
                {
                    contact.IsActive = isActive;
                    session.Update(contact);
                    session.Flush();
                    return new HttpStatusCodeResult(200);
                }
                return new HttpNotFoundResult("Contact not found");
            }
        }
        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            var userId = (Guid)TempData.Peek("UserId");
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Get<User>(userId);
                if (contact != null && user != null)
                {
                    contact.User = user; // Associate the contact with the user
                    session.Save(contact);
                    session.Flush();
                    return Json(new { success = true, contactId = contact.Id });
                }
                return new HttpStatusCodeResult(500, "Error creating contact");
            }
        }
        public ActionResult GetContact(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var contact = session.Get<Contact>(id);
                return Json(new
                {
                    contact.Id,
                    contact.FirstName,
                    contact.LastName,
                    contact.IsActive
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            int id = (int)contact.Id;

            using (var session = NHibernateHelper.CreateSession())
            {
                var existingItem = session.Get<Contact>(id);
                if (existingItem != null)
                {
                    existingItem.FirstName = contact.FirstName;
                    existingItem.LastName = contact.LastName;
                    existingItem.IsActive = contact.IsActive;
                    session.Update(existingItem);
                    session.Flush();
                    return Json(new { success = true });
                }
                return new HttpStatusCodeResult(500, "Error creating contact");
            }
        }
        public ActionResult Details(int id)
        {
            if (id != 0)
            {
                return /*Json(new { success = true }),*/ RedirectToAction("Index", "ContactDetails");
            }
            return new HttpStatusCodeResult(500, "Error viewing details of the contact");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var contact = session.Get<Contact>(id);
                contact.IsActive = false;
                session.Update(contact);
                session.Flush();
                return Json(new { success = true });
            }
        }
    }
}