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
    public class ServiceBooksController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

		// GET: api/ServiceAuthor
        [HttpGet]
		public IQueryable<ServiceAuthor> GetAuthor()
		{
			return db.author;
		}
		//// GET: api/ServiceBranch
		//public IQueryable<ServiceBookBranch> GetBranch()
		//{
		//    return db.bookBranch;
		//}
		//// GET: api/ServicePublication
		//public IQueryable<ServiceBookPublication> GetPublication()
		//{
		//    return db.bookPublication;
		//}       
		// GET: api/ServiceBooks       
        [Route("Books/getBooks")]
		public IQueryable<ServiceBooks> Getbook()
        {
            return db.book;
        }

        // GET: api/ServiceBooks/5
        
        [ResponseType(typeof(ServiceBooks))]
        public IHttpActionResult GetServiceBooks(int id)
        {
            ServiceBooks serviceBooks = db.book.Find(id);
            if (serviceBooks == null)
            {
                return NotFound();
            }

            return Ok(serviceBooks);
        }

        // PUT: api/ServiceBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceBooks(int id, ServiceBooks serviceBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceBooks.serviceBookId)
            {
                return BadRequest();
            }

            db.Entry(serviceBooks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBooksExists(id))
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

        // POST: api/ServiceBooks
        [ResponseType(typeof(ServiceBooks))]
        public IHttpActionResult PostServiceBooks(ServiceBooks serviceBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.book.Add(serviceBooks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceBooks.serviceBookId }, serviceBooks);
        }

        // DELETE: api/ServiceBooks/5
        [ResponseType(typeof(ServiceBooks))]
        public IHttpActionResult DeleteServiceBooks(int id)
        {
            ServiceBooks serviceBooks = db.book.Find(id);
            if (serviceBooks == null)
            {
                return NotFound();
            }

            db.book.Remove(serviceBooks);
            db.SaveChanges();

            return Ok(serviceBooks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceBooksExists(int id)
        {
            return db.book.Count(e => e.serviceBookId == id) > 0;
        }
    }
}