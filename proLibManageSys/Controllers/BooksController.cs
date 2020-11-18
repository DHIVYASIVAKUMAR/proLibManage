﻿using System;
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
    public class BooksController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: Books
        public ActionResult Index()
        {
            /* var Book = db.book.ToList();
             ViewBag.book = Book;*/

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
            var authorList = new List<string>() { "J.K Rowling", "TCRC", "John", "peter", "Jessica", "Moshe cholie" };
            ViewBag.authorList = authorList;

            var list = new List<string>() { "stories", "Data structure & algorithm", "Web Developement", "programming", "Languages" };
            ViewBag.list = list;
            var publicationsList = new List<string>() { "Bloomsbury", "John Wiley", "MIT Press", "IIT Press" };
            ViewBag.publicationsList = publicationsList;
            
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookId,bookName,authorName,serialNumber,branch,publications,isAvailable")] Books books)
        {
			var authorList = new List<string>() {"J.K Rowling", "TCRC", "John", "peter", "Jessica", "Moshe cholie" };
            ViewBag.authorList = authorList;
            
            var list = new List<string>() { "stories","Data structure & algorithm","Web Developement","programming","Languages" };
            
            ViewBag.list = list;
            
            var publicationsList = new List<string>() { "Bloomsbury", "John Wiley", "MIT Press" ,"IIT Press"};
            ViewBag.publicationsList = publicationsList;
            
            if (ModelState.IsValid)
            {
                db.book.Add(books);
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

        /*
        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.book.Find(id);
            db.book.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            
            var Book = db.book.FirstOrDefault(b => b.bookId == id);
            if (Book != null) {
                db.book.Remove(Book);
                db.SaveChanges();
                result = true;
            }                                                                                               
            return Json(result,JsonRequestBehavior.AllowGet);
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
