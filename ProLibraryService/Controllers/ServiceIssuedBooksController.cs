using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProLibraryService.DataContext;
using ProLibraryService.Models;
using ProLibraryService.ViewModels;

namespace ProLibraryService.Controllers
{
    public class ServiceIssuedBooksController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
     List<ServiceBooks> books = new List<ServiceBooks>();
            List<ServiceStudents> students = new List<ServiceStudents>();
            List<ServiceIssuedBooks> issuedBooks = new List<ServiceIssuedBooks>();
        // GET: api/ServiceIssuedBooks/GetissuedBook
        public IHttpActionResult GetissuedBook()
        {
       
            var issuedBookViewModel = (from i in db.issuedBook
                                       join b in db.book on i.bookId equals b.serviceBookId
                                       join s in db.student on i.studentId equals s.serviceStudentId
                                       select new ServiceIssuedBookViewModel
                                       { 
                                           serviceBookId = b.serviceBookId,
                                           serviceBookName = b.serviceBookName,
                                           serviceAuthorName = b.serviceAuthorName,
                                           serviceBranch = b.serviceBranch,
                                           servicePublication = b.servicePublications,
                                           serviceStudentName = s.serviceStudentName,
                                           serviceStudentEmail = s.serviceEmail,
                                           serviceFromDate = i.serviceFromDate,
                                           serviceToDate = i.serviceToDate,
                                           serviceIssuedId = i.serviceIssuedId
                                       }).ToList();
            var result = issuedBookViewModel.Select(x=> new ServiceIssuedBookViewModel 
            {
                serviceBookId = x.serviceBookId,
                serviceBookName = x.serviceBookName,
                serviceAuthorName = x.serviceAuthorName,
                serviceBranch = x.serviceBranch,
                servicePublication = x.servicePublication,
                serviceStudentEmail = x.serviceStudentEmail,
                serviceDisplayFromDate = x.serviceFromDate.ToString("MM/dd/yyyy"),
                serviceDisplayToDate = x.serviceToDate.ToString("MM/dd/yyyy"),
                serviceIssuedId = x.serviceIssuedId
            }).ToList();
            return Ok(result);
        }

        // GET: api/ServiceIssuedBooks/5
        [ResponseType(typeof(ServiceIssuedBooks))]
        public IHttpActionResult GetServiceIssuedBooks(int id)
        {           
            var issuedBookViewModel = (from i in db.issuedBook
                                       where i.serviceIssuedId == id
                                       join b in db.book on i.bookId equals b.serviceBookId
                                       join s in db.student on i.studentId equals s.serviceStudentId
                                       select new ServiceIssuedBookViewModel
                                       {
                                           serviceBookId = b.serviceBookId,
                                           serviceBookName = b.serviceBookName,
                                           serviceAuthorName = b.serviceAuthorName,
                                           serviceBranch = b.serviceBranch,
                                           servicePublication = b.servicePublications,
                                           serviceStudentName = s.serviceStudentName,
                                           serviceStudentEmail = s.serviceEmail,
                                           serviceFromDate = i.serviceFromDate,
                                           serviceToDate = i.serviceToDate,
                                           serviceIssuedId = i.serviceIssuedId
                                       }).ToList();

            return Ok(issuedBookViewModel.FirstOrDefault());
        }

        // PUT: api/ServiceIssuedBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceIssuedBooks(int id, ServiceIssuedBooks serviceIssuedBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceIssuedBooks.serviceIssuedId)
            {
                return BadRequest();
            }

            db.Entry(serviceIssuedBooks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceIssuedBooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ServiceIssuedBooks
        [ResponseType(typeof(ServiceIssuedBooks))]
        public IHttpActionResult PostServiceIssuedBooks(ServiceIssuedBooks serviceIssuedBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Book = db.book.FirstOrDefault(b => b.serviceBookId == serviceIssuedBooks.bookId);
            if (Book != null)
            {
                Book.serviceIsAvailable = false;
                db.Entry(Book).State = EntityState.Modified;
                db.SaveChanges();
            }
            db.issuedBook.Add(serviceIssuedBooks);
            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = serviceIssuedBooks.serviceIssuedId }, serviceIssuedBooks);
        }

        // DELETE: api/ServiceIssuedBooks/5
        [ResponseType(typeof(ServiceIssuedBooks))]
        public IHttpActionResult DeleteServiceIssuedBooks(int id)
        {
            ServiceIssuedBooks serviceIssuedBooks = db.issuedBook.Find(id);
            var Book = db.book.FirstOrDefault(b => b.serviceBookId == serviceIssuedBooks.bookId);
            if (serviceIssuedBooks == null)
            {
                return NotFound();
            }
            db.issuedBook.Remove(serviceIssuedBooks);
            db.SaveChanges();           
            
            if (Book != null)
            {
                Book.serviceIsAvailable = true;
                db.Entry(Book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Ok(serviceIssuedBooks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceIssuedBooksExists(int id)
        {
            return db.issuedBook.Count(e => e.serviceIssuedId == id) > 0;
        }
    }
}