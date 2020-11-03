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

namespace proLibManageSys.Controllers
{
    public class IssuedBooksController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: IssuedBooks
        public ActionResult Index()
        {
            return View(db.issuedBook.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssuedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "issuedId,issuedBookName,issuedAuthorName,issuedBookBranch,issuedBookPublications,issuedStudentName,issuedStudentEmail,fromDate,toDate")] IssuedBooks issuedBooks)
        {
            if (ModelState.IsValid)
            {
                db.issuedBook.Add(issuedBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(issuedBooks);
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
