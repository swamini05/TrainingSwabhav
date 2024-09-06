using System.Linq;
using System.Web.Mvc;
using FluentNHibernateDemo.Data;
using FluentNHibernateDemo.Models;

namespace FluentNHibernateDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var products = session.Query<Product>().ToList();
                return View(products);
            }

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(product);
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var product = session.Get<Product>(id);
                return View(product);

            }
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(product);
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var product = session.Get<Product>(id);
                return View(product);

            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteproduct(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var product = session.Get<Product>(id);
                    session.Delete(product);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }

        }

    }
}