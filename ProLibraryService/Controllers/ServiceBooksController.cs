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
using System.Web.Http.Results;
//using System.Web.Mvc;
using ProLibraryService.DataContext;
using ProLibraryService.Models;

namespace ProLibraryService.Controllers
{
    public class ServiceBooksController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: api/ServiceBranch
        public IQueryable<ServiceBookBranch> GetBranch()
        {
            return db.bookBranch;
        }

        // GET: api/ServicePublication
        public IQueryable<ServiceBookPublication> GetPublication()
        {
            return db.bookPublication;
        }
        // GET: api/ServiceBooks       
        //[Route("api/ServiceBooks/getBooks")]
        public IQueryable<ServiceBooks> Getbook()
        {
            return db.book;
        }
        public IHttpActionResult Getbooks()
        {
            return Json(new { data = db.book });
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

        [HttpPut]
		[ResponseType(typeof(ServiceBooks))]
        public IHttpActionResult PutServiceBooks(int id, ServiceBooks serviceBooks)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            if (ModelState.IsValid)
            {
                var existingBook = db.book.Where(b => b.serviceBookId == serviceBooks.serviceBookId).FirstOrDefault<ServiceBooks>();
                existingBook.serviceBookName = serviceBooks.serviceBookName;
                existingBook.serviceAuthorName = serviceBooks.serviceAuthorName;
                existingBook.serviceBranch = serviceBooks.serviceBranch;
                existingBook.servicePublications = serviceBooks.servicePublications;
                existingBook.serviceSerialNumber = serviceBooks.serviceSerialNumber;
                existingBook.serviceIsAvailable = serviceBooks.serviceIsAvailable;
                db.SaveChanges();
                return Ok(existingBook);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

            //// PUT: api/ServiceBooks/5
            //[ResponseType(typeof(ServiceBooks))]
            //public IHttpActionResult PutServiceBooks(ServiceBooks serviceBooks)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Entry(serviceBooks).State = EntityState.Modified;
            //        db.SaveChanges();               
            //    }            

            //    return StatusCode(HttpStatusCode.NoContent);
            //}
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

        [ResponseType(typeof(ServiceBookBranch))]
        public IHttpActionResult PostServiceBranches(ServiceBookBranch serviceBookBranches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.bookBranch.Add(serviceBookBranches);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceBookBranches.serviceBookBranchId }, serviceBookBranches);
        }

        [ResponseType(typeof(ServiceBookPublication))]
        public IHttpActionResult PostServicePublications(ServiceBookPublication serviceBookPublication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bookPublication.Add(serviceBookPublication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceBookPublication.serviceBookPublicationId }, serviceBookPublication);
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