using System.Linq;
using System.Web.Mvc;
using ContactAppMiniProject.Data;
using ContactAppMiniProject.Models;

namespace ContactAppMiniProject.Controllers
{
    public class ContactDetailsController : Controller
    {
        public ActionResult Index(int contactId)
        {
            TempData["ContactId"] = contactId;
            return View();
        }
        public ActionResult GetData(int page, int rows, string sidx, string sord, string searchString)
        {
            var contactId = (int)TempData.Peek("ContactId");
            using (var session = NHibernateHelper.CreateSession())
            {
                var contactDetails = session.Query<ContactDetail>().Where(cd => cd.Contact.Id == contactId).ToList();

                int totalCount = contactDetails.Count();
                int totalPages = (int)System.Math.Ceiling((double)totalCount / rows);

                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalCount,
                    rows = (from contactDetail in contactDetails
                            orderby sidx + " " + sord
                            select new
                            {
                                cell = new string[]
                                {
                                    contactDetail.Id.ToString(),
                                    contactDetail.Type,
                                    contactDetail.Value.ToString()

                                }
                            }).Skip((page - 1) * rows).Take(rows).ToArray()

                };

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Add(ContactDetail contactDetail)
        {
            var contactId = (int)TempData.Peek("ContactId");
            using (var session = NHibernateHelper.CreateSession())
            {
                // Fetch the associated contact
                var contact = session.Query<Contact>().SingleOrDefault(cd => cd.Id == contactId);
                if (contact == null)
                {
                    return Json(new { success = false, message = "Contact not found." });
                }

                contactDetail.Contact = contact; // Assign the contact to the detail

                using (var transaction = session.BeginTransaction())
                {
                    session.Save(contactDetail);
                    transaction.Commit();
                    return Json(new { success = true, message = "Added" });
                }
            }
        }

        // POST: Edit an existing contact detail
        [HttpPost]
        public ActionResult Edit(ContactDetail contactDetail)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var existingDetail = session.Get<ContactDetail>(contactDetail.Id);
                if (existingDetail != null)
                {
                    existingDetail.Type = contactDetail.Type;
                    existingDetail.Value = contactDetail.Value;

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(existingDetail);
                        transaction.Commit();
                    }


                    return Json(new { success = true, message = "Contact detail edited successfully" });
                }
            }

            return Json(new { success = false, message = "Contact detail not found." });
        }

        // POST: Delete a contact detail
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var contactDetail = session.Get<ContactDetail>(id);
                if (contactDetail != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(contactDetail);
                        transaction.Commit();
                    }

                    return Json(new { success = true, message = "Contact detail deleted successfully." });
                }
            }

            return Json(new { success = false, message = "Contact detail not found." });
        }
    }
}
