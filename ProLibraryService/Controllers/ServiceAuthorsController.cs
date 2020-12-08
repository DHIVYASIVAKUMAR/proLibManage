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
    public class ServiceAuthorsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ServiceAuthors
        public IQueryable<ServiceAuthor> Getauthor()
        {
            return db.author;
        }

        // GET: api/ServiceAuthors/5
        [ResponseType(typeof(ServiceAuthor))]
        public IHttpActionResult GetServiceAuthor(int id)
        {
            ServiceAuthor serviceAuthor = db.author.Find(id);
            if (serviceAuthor == null)
            {
                return NotFound();
            }

            return Ok(serviceAuthor);
        }

        // PUT: api/ServiceAuthors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceAuthor(int id, ServiceAuthor serviceAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceAuthor.serviceAuthorId)
            {
                return BadRequest();
            }

            db.Entry(serviceAuthor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAuthorExists(id))
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

        // POST: api/ServiceAuthors
        [ResponseType(typeof(ServiceAuthor))]
        public IHttpActionResult PostServiceAuthor(ServiceAuthor serviceAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.author.Add(serviceAuthor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceAuthor.serviceAuthorId }, serviceAuthor);
        }

        // DELETE: api/ServiceAuthors/5
        [ResponseType(typeof(ServiceAuthor))]
        public IHttpActionResult DeleteServiceAuthor(int id)
        {
            ServiceAuthor serviceAuthor = db.author.Find(id);
            if (serviceAuthor == null)
            {
                return NotFound();
            }

            db.author.Remove(serviceAuthor);
            db.SaveChanges();

            return Ok(serviceAuthor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceAuthorExists(int id)
        {
            return db.author.Count(e => e.serviceAuthorId == id) > 0;
        }
    }
}