using System;
using System.Linq;
using System.Web.Mvc;
using CombinationBooks.Data;
using CombinationBooks.Models;
using NHibernate.Linq;

namespace CombinationBooks.Controllers
{
    [Authorize]
    public class AuthorDetailsController : Controller
    {
        public ActionResult Index()
        {
            var authId = (Guid)TempData.Peek("AuthorId");
            using (var session = NHibernateHelper.CreateSession())
            {
                var authorDetails = session.Query<AuthorDetails>().Fetch(ad => ad.Author).FirstOrDefault(ad => ad.Author.Id == authId);

                if (authorDetails == null || authorDetails.City == null)
                {
                    return RedirectToAction("Create", new { authId = authId });
                }

                return View(authorDetails);
            }
        }

        public ActionResult Create(Guid authId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var author = session.Get<Author>(authId);
                if (author == null)
                {
                    return HttpNotFound();
                }

                // Check if the author already has details
                var existingDetails = session.Query<AuthorDetails>().FirstOrDefault(ad => ad.Author.Id == authId);
                if (existingDetails != null)
                {
                    // Redirect to edit if the details already exist
                    return RedirectToAction("Edit", new { id = existingDetails.Id });
                }

                ViewBag.AuthorId = authId;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(AuthorDetails authorDetails, Guid authId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var author = session.Get<Author>(authId);

                    if (author == null)
                    {
                        return HttpNotFound();
                    }

                    // Check if the author already has details
                    var existingDetails = session.Query<AuthorDetails>().FirstOrDefault(ad => ad.Author.Id == authId);
                    if (existingDetails != null)
                    {
                        // Prevent duplicate creation
                        ModelState.AddModelError("", "Author already has details. Please edit the existing details.");
                        return View(authorDetails);
                    }

                    authorDetails.Author = author;
                    session.Save(authorDetails);
                    transaction.Commit();
                    return RedirectToAction("Index", "Author", new { authId = author.Id });
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var authorDetails = session.Get<AuthorDetails>(id);

                if (authorDetails == null)
                {
                    return HttpNotFound();
                }

                return View(authorDetails);
            }
        }

        [HttpPost]
        public ActionResult Edit(AuthorDetails authorDetails)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var existingDetails = session.Get<AuthorDetails>(authorDetails.Id);

                if (existingDetails == null)
                {
                    return HttpNotFound();
                }

                existingDetails.Street = authorDetails.Street;
                existingDetails.City = authorDetails.City;
                existingDetails.State = authorDetails.State;
                existingDetails.Country = authorDetails.Country;

                using (var transaction = session.BeginTransaction())
                {
                    session.Update(existingDetails);
                    transaction.Commit();
                }

                return RedirectToAction("Index", new { authId = existingDetails.Author.Id });
            }
        }

        // GET: Delete confirmation
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var authorDetails = session.Get<AuthorDetails>(id);

                if (authorDetails == null)
                {
                    return HttpNotFound();
                }

                return View(authorDetails);
            }
        }

        // POST: Confirm delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var authorDetails = session.Get<AuthorDetails>(id);

                if (authorDetails != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(authorDetails);
                        transaction.Commit();
                    }

                    return RedirectToAction("Index", new { authId = authorDetails.Author.Id });
                }

                return HttpNotFound();
            }
        }
    }
}