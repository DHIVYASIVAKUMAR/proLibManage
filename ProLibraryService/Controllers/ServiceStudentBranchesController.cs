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
    public class ServiceStudentBranchesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ServiceStudentBranches
        public IQueryable<ServiceStudentBranch> GetstudentBranches()
        {
            return db.studentBranches;
        }

        // GET: api/ServiceStudentBranches/5
        [ResponseType(typeof(ServiceStudentBranch))]
        public IHttpActionResult GetServiceStudentBranch(int id)
        {
            ServiceStudentBranch serviceStudentBranch = db.studentBranches.Find(id);
            if (serviceStudentBranch == null)
            {
                return NotFound();
            }

            return Ok(serviceStudentBranch);
        }

        // PUT: api/ServiceStudentBranches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceStudentBranch(int id, ServiceStudentBranch serviceStudentBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceStudentBranch.serviceStudentBranchId)
            {
                return BadRequest();
            }

            db.Entry(serviceStudentBranch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceStudentBranchExists(id))
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

        // POST: api/ServiceStudentBranches
        [ResponseType(typeof(ServiceStudentBranch))]
        public IHttpActionResult PostServiceStudentBranch(ServiceStudentBranch serviceStudentBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.studentBranches.Add(serviceStudentBranch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceStudentBranch.serviceStudentBranchId }, serviceStudentBranch);
        }

        // DELETE: api/ServiceStudentBranches/5
        [ResponseType(typeof(ServiceStudentBranch))]
        public IHttpActionResult DeleteServiceStudentBranch(int id)
        {
            ServiceStudentBranch serviceStudentBranch = db.studentBranches.Find(id);
            if (serviceStudentBranch == null)
            {
                return NotFound();
            }

            db.studentBranches.Remove(serviceStudentBranch);
            db.SaveChanges();

            return Ok(serviceStudentBranch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceStudentBranchExists(int id)
        {
            return db.studentBranches.Count(e => e.serviceStudentBranchId == id) > 0;
        }
    }
}