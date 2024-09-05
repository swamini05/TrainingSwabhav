using System.Linq;
using System.Web.Mvc;
using OneToOneStudents.Data;
using OneToOneStudents.Models;

namespace OneToOneStudents.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var users = session.Query<Student>().ToList();
                return View(users);
            }

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student.Course.Id == 0)
            {
                ModelState.Remove("Course.Id");
            }

            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }


            return View(student);
        }
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(s => s.Id == id);
                return View(student);
            }

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Update(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                return View(student);

            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deletestudent(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Get<Student>(id);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }

        }
    }
}