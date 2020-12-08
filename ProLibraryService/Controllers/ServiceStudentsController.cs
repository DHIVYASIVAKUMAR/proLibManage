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
    public class ServiceStudentsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ServiceStudents
        public IQueryable<ServiceStudents> Getstudent()
        {
            return db.student;
        }

        // GET: api/ServiceStudents/5
        [ResponseType(typeof(ServiceStudents))]
        public IHttpActionResult GetServiceStudents(int id)
        {
            ServiceStudents serviceStudents = db.student.Find(id);
            if (serviceStudents == null)
            {
                return NotFound();
            }

            return Ok(serviceStudents);
        }

        // PUT: api/ServiceStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceStudents(int id, ServiceStudents serviceStudents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceStudents.serviceStudentId)
            {
                return BadRequest();
            }

            db.Entry(serviceStudents).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceStudentsExists(id))
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

        // POST: api/ServiceStudents
        [ResponseType(typeof(ServiceStudents))]
        public IHttpActionResult PostServiceStudents(ServiceStudents serviceStudents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.student.Add(serviceStudents);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceStudents.serviceStudentId }, serviceStudents);
        }

        // DELETE: api/ServiceStudents/5
        [ResponseType(typeof(ServiceStudents))]
        public IHttpActionResult DeleteServiceStudents(int id)
        {
            ServiceStudents serviceStudents = db.student.Find(id);
            if (serviceStudents == null)
            {
                return NotFound();
            }

            db.student.Remove(serviceStudents);
            db.SaveChanges();

            return Ok(serviceStudents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceStudentsExists(int id)
        {
            return db.student.Count(e => e.serviceStudentId == id) > 0;
        }
    }
}