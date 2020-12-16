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

namespace ProLibraryService.Controllers
{
    public class ServiceIssuedBooksController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ServiceIssuedBooks
        public IQueryable<ServiceIssuedBooks> GetissuedBook()
        {
            return db.issuedBook;
        }

        // GET: api/ServiceIssuedBooks/5
        [ResponseType(typeof(ServiceIssuedBooks))]
        public IHttpActionResult GetServiceIssuedBooks(int id)
        {
            ServiceIssuedBooks serviceIssuedBooks = db.issuedBook.Find(id);
            if (serviceIssuedBooks == null)
            {
                return NotFound();
            }

            return Ok(serviceIssuedBooks);
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