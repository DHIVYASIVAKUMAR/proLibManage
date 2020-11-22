using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proLibManageSys.Data;
using proLibManageSys.Models;
using proLibManageSys.ViewModels;

namespace proLibManageSys.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class IssuedBooksController : Controller
    {
        private ModelsContext db = new ModelsContext();
        List<Books> book = new List<Books>();
        List<Students> student = new List<Students>();
        List<IssuedBooks> issuedBooks = new List<IssuedBooks>();

        // GET: IssuedBooks
        public ActionResult Index()
        {
           
            var issuedBookViewModel = from i in issuedBooks
                                 join b in book on i.bookId equals b.bookId
                                 join s in student on i.studentId equals s.studentId
                                 select new
                                 {
                                     bookName = b.bookName,
                                     authorName = b.authorName,
                                     branch = b.branch,
                                     publication = b.publications,
                                     studentName = s.studentName,
                                     studentEmail = s.email,
                                     fromDate = i.fromDate,
                                     toDate = i.toDate
                                 };

            return View(issuedBookViewModel);
        }

        // GET: IssuedBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBooks issuedBooks = db.issuedBook.Find(id);
            if (issuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(issuedBooks);
        }

        // GET: IssuedBooks/Create
        public ActionResult Create(int id)
        {
            var book = (from books in db.book
						where books.bookId == id
						select books).FirstOrDefault();
            ViewBag.bookName = book.bookName;
            ViewBag.authorName = book.authorName;
            ViewBag.bookId = book.bookId;
           
            return View(db.student.ToList());
        }

        // POST: IssuedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "issuedId,issuedBookName,issuedAuthorName,issuedBookBranch,issuedBookPublications,issuedStudentName,issuedStudentEmail,fromDate,toDate")] IssuedBooks issuedBooks)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.issuedBook.Add(issuedBooks);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(issuedBooks);
        //}

        [HttpPost]
        public JsonResult BookIssue(int bookId,int studentId,string fromDate,string toDate) {

            var issuedBook = new IssuedBooks();
            issuedBook.bookId = bookId;
            issuedBook.studentId = studentId;
            issuedBook.fromDate = fromDate;
            issuedBook.toDate = toDate;

            var Book = db.book.FirstOrDefault(b => b.bookId == bookId);
            if (issuedBook != null && Book != null)
            {
                db.issuedBook.Add(issuedBook);
                db.SaveChanges();
                Book.isAvailable = false;

                db.Entry(Book).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = "success" });
            }
            else {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: IssuedBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBooks issuedBooks = db.issuedBook.Find(id);
            if (issuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(issuedBooks);
        }

        // POST: IssuedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "issuedId,issuedBookName,issuedAuthorName,issuedBookBranch,issuedBookPublications,issuedStudentName,issuedStudentEmail,fromDate,toDate")] IssuedBooks issuedBooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuedBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issuedBooks);
        }

        // GET: IssuedBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBooks issuedBooks = db.issuedBook.Find(id);
            if (issuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(issuedBooks);
        }

        // POST: IssuedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssuedBooks issuedBooks = db.issuedBook.Find(id);
            db.issuedBook.Remove(issuedBooks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
