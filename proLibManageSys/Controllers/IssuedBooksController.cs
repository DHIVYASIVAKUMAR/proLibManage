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
       
        public ActionResult Index()
        {
            var issuedBookViewModel = (from i in db.issuedBook
                                      join b in db.book on i.bookId equals b.bookId
                                      join s in db.student on i.studentId equals s.studentId
                                      select new IssuedBookViewModel
                                      {
                                          bookId = b.bookId,
                                          bookName = b.bookName,
                                          authorName = b.authorName,
                                          branch = b.branch,
                                          publication = b.publications,
                                          studentName = s.studentName,
                                          studentEmail = s.email,
                                         fromDate = i.fromDate,
                                         toDate = i.toDate,
                                          issuedId = i.issuedId
                                          //book = b,
                                          //student = s,
                                          //issuedBook = i
                                      }).ToList();

            var result = issuedBookViewModel.Select(x => new IssuedBookViewModel
            {
                bookId = x.bookId,
                bookName = x.bookName,
                authorName = x.authorName,
                branch = x.branch,
                publication = x.publication,
                studentName = x.studentName,
                studentEmail = x.studentEmail,
                displayToDate = x.toDate.ToString("MM/dd/yyyy"),
                displayFromDate = x.fromDate.ToString("MM/dd/yyyy"),
                issuedId = x.issuedId
            }).ToList();
            
            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var issuedBookViewModel = from i in db.issuedBook
                                      where i.issuedId == id
                                      join b in db.book on i.bookId equals b.bookId
                                      join s in db.student on i.studentId equals s.studentId
                                      select new IssuedBookViewModel
                                      {
                                          bookId = b.bookId,
                                          bookName = b.bookName,
                                          authorName = b.authorName,
                                          branch = b.branch,
                                          publication = b.publications,
                                          studentName = s.studentName,
                                          studentEmail = s.email,
                                          fromDate = i.fromDate,
                                          toDate = i.toDate,
                                          issuedId = i.issuedId
                                          //book = b,
                                          //student = s,
                                          //issuedBook = i
                                      };
            return View(issuedBookViewModel.FirstOrDefault());           
        }
     
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
        
        [HttpPost]
        public JsonResult BookIssue(IssuedBooks issuedBooks){
			var Book = db.book.FirstOrDefault(b => b.bookId == issuedBooks.bookId);
            if (issuedBooks != null && Book != null)
            {
                db.issuedBook.Add(issuedBooks);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var issuedBookViewModel = (from i in db.issuedBook
                                      where i.issuedId == id
                                      join b in db.book on i.bookId equals b.bookId
                                      join s in db.student on i.studentId equals s.studentId
                                      select new IssuedBookViewModel
                                      {
                                          bookId = b.bookId,
                                          bookName = b.bookName,
                                          authorName = b.authorName,
                                          branch = b.branch,
                                          publication = b.publications,
                                          studentName = s.studentName,
                                          studentEmail = s.email,
                                          fromDate = i.fromDate,
                                          toDate = i.toDate,
                                          issuedId = i.issuedId
                                          //book = b,
                                          //student = s,
                                          //issuedBook = i
                                      }).ToList();
            var result = issuedBookViewModel.Select(x => new IssuedBookViewModel
            {
                bookId = x.bookId,
                bookName = x.bookName,
                authorName = x.authorName,
                branch = x.branch,
                publication = x.publication,
                studentName = x.studentName,
                studentEmail = x.studentEmail,
                displayToDate = x.toDate.ToString("MM/dd/yyyy"),
                displayFromDate = x.fromDate.ToString("MM/dd/yyyy"),
                issuedId = x.issuedId
            }).ToList();

           // return View(result);
            return View(result.FirstOrDefault());
        }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "issuedId,issuedBookName,issuedAuthorName,issuedBookBranch,issuedBookPublications,issuedStudentName,issuedStudentEmail,fromDate,toDate")] IssuedBooks issuedBooks)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(issuedBooks).State = EntityState.Modified;
        //db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(issuedBooks);
        //    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( IssuedBookViewModel issuedBookViewModel)
        {
            if (ModelState.IsValid)
            {
                IssuedBooks issuedBooks = db.issuedBook.Find(issuedBookViewModel.issuedId);
                var fromDate = issuedBookViewModel.displayFromDate;
                var toDate = issuedBookViewModel.displayToDate;
                issuedBooks.fromDate = Convert.ToDateTime(fromDate);
                issuedBooks.toDate = Convert.ToDateTime(toDate);

                db.Entry(issuedBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issuedBooks);
        }


        [HttpPost]
        public JsonResult Return(int BookId, int IssuedBookId) 
        {
            bool result = false;
            var book = db.book.FirstOrDefault(b => b.bookId == BookId);
            var issuedBook = db.issuedBook.FirstOrDefault(i => i.issuedId == IssuedBookId);
            if (book != null && issuedBook != null) 
            {
                book.isAvailable = true;
                db.issuedBook.Remove(issuedBook);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
