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
    public class BooksController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: Books
        public ActionResult Index()
        {
			return View(db.book.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            BooksViewModel booksViewModel = new BooksViewModel();

            booksViewModel.authors = db.author.ToList();
                // db.author.Select(x => new SelectListItem { Text = x.authorName, Value = x.authorName }).ToList();
            booksViewModel.bookBranches = db.bookBranch.ToList();
            booksViewModel.bookPublications = db.bookPublication.ToList();          
            
            return View(booksViewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksViewModel books)
        {            
            if (ModelState.IsValid)
            {
                db.book.Add(books.book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookId,bookName,authorName,serialNumber,branch,publications,isAvailable")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            
            var Book = db.book.FirstOrDefault(b => b.bookId == id);
            Book.isAvailable = false;
            if (Book != null) {
                db.book.Remove(Book);
                db.SaveChanges();
                result = true;
            }                                                                                               
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddAuthor(string name)
        {
            var author = new Author();
            author.authorName = name;
            db.author.Add(author);
			db.SaveChanges();
            return Json(new { result = "success"});
        }
        [HttpPost]
        public JsonResult AddBranch(string name)
        {
            var bookBranch = new BookBranch();
            bookBranch.branch = name;
            db.bookBranch.Add(bookBranch);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public JsonResult AddPublication(string name)
        {
            var publication = new BookPublication();
            publication.publications = name;
            db.bookPublication.Add(publication);
            db.SaveChanges();
            return Json(new { result = "success" });
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
