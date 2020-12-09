using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ProLibraryService.DataContext;
using ProLibraryService.Models;

namespace ProLibraryService.Controllers
{
    public class ServiceBooksMvcController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //// GET: ServiceBooksMvc
        //public ActionResult Index()
        //{
        //    return View(db.book.ToList());
        //}
        public ActionResult Index()
        {
            List<ServiceBooks> books = SearchBooks("");
            return View(books);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            List<ServiceBooks> books = SearchBooks(name);
            return View(books);
        }

        private static List<ServiceBooks> SearchBooks(string name)
        {
            string apiUrl = "https://localhost:44369/api/ServiceBooks";
            var input = new
            {
                Name = name,
            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = apiUrl;
            //string json = client.UploadString(apiUrl + "/Getbook", inputJson);
            List<ServiceBooks> books = (new JavaScriptSerializer()).Deserialize<List<ServiceBooks>>(json);
            return books;
        }

        // GET: ServiceBooksMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceBooks serviceBooks = db.book.Find(id);
            if (serviceBooks == null)
            {
                return HttpNotFound();
            }
            return View(serviceBooks);
        }

        // GET: ServiceBooksMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceBooksMvc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serviceBookId,serviceBookName,serviceSerialNumber,serviceAuthorName,serviceBranch,servicePublications,serviceIsAvailable")] ServiceBooks serviceBooks)
        {
            if (ModelState.IsValid)
            {
                db.book.Add(serviceBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceBooks);
        }

        // GET: ServiceBooksMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceBooks serviceBooks = db.book.Find(id);
            if (serviceBooks == null)
            {
                return HttpNotFound();
            }
            return View(serviceBooks);
        }

        // POST: ServiceBooksMvc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "serviceBookId,serviceBookName,serviceSerialNumber,serviceAuthorName,serviceBranch,servicePublications,serviceIsAvailable")] ServiceBooks serviceBooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceBooks);
        }

        // GET: ServiceBooksMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceBooks serviceBooks = db.book.Find(id);
            if (serviceBooks == null)
            {
                return HttpNotFound();
            }
            return View(serviceBooks);
        }

        // POST: ServiceBooksMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceBooks serviceBooks = db.book.Find(id);
            db.book.Remove(serviceBooks);
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
