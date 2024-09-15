using System;
using System.Linq;
using System.Web.Mvc;
using CombinationBooks.Data;
using CombinationBooks.Models;

namespace CombinationBooks.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookDetails(Guid authId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var books = session.Query<Book>().Where(o => o.Author.Id == authId).ToList();

                TempData["AuthorId"] = authId;
                return View(books);
            }
        }
        public ActionResult Create()
        {
            if (TempData["AuthorId"] != null)
            {
                var authId = (Guid)TempData.Peek("AuthorId");
                ViewBag.AuthorId = authId;

                TempData.Keep("AuthorId");

                var book = new Book();
                return View(book);
            }

            return RedirectToAction("Index", "Author");
        }
        [HttpPost]
        public ActionResult Create(Book book, Guid authId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    book.Author = session.Get<Author>(authId);
                    session.Save(book);
                    transaction.Commit();
                }

                return RedirectToAction("BookDetails", new { authId = authId });
            }
        }
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var book = session.Get<Book>(id);

                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {

            using (var session = NHibernateHelper.CreateSession())
            {
                var existingBook = session.Get<Book>(book.Id);

                if (existingBook == null)
                {
                    return HttpNotFound();
                }

                var author = session.Get<Author>(existingBook.Author.Id);

                if (author == null)
                {
                    return HttpNotFound();
                }

                existingBook.Description = book.Description;
                existingBook.Name = book.Name;
                existingBook.Genre = book.Genre;
                existingBook.Author = author;

                using (var transaction = session.BeginTransaction())
                {
                    session.Update(existingBook);
                    transaction.Commit();
                    return RedirectToAction("BookDetails", new { authId = existingBook.Author.Id });
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var book = session.Get<Book>(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var book = session.Get<Book>(id);
                if (book != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(book);
                        transaction.Commit();
                        return RedirectToAction("BookDetails", new { authId = book.Author.Id });
                    }
                }
                return HttpNotFound();
            }
        }
    }
}