using System;
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
    public class StudentsController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.student.ToList());
        }
        
        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.student.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.studentBranches = db.studentBranches.ToList();
            return View(studentViewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentObj)
        {
            if (ModelState.IsValid)
            {
                db.student.Add(studentObj.students);
                db.SaveChanges();
				return RedirectToAction("Index");
            }

            return View(studentObj);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.student.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,studentName,studentBranch,gender,phoneNumber,address,city,email,password")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Students students = db.student.Find(id);
        //    if (students == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(students);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Students students = db.student.Find(id);
        //    db.student.Remove(students);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            var student = db.student.FirstOrDefault(s => s.studentId == id);
            if (student != null) {
                db.student.Remove(student);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddBranch(string name) 
        {
            var branchs = new StudentBranch();
            branchs.studentBranch = name;
			db.studentBranches.Add(branchs);
            db.SaveChanges();
            return Json(new { result = "success" });
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
