using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCrud.Models;

namespace StudentCrud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Students.ToList());
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Students.Where(x => x.id==id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Students.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (DBModel db = new DBModel())
                {

                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Students.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                   student= db.Students.Where(x => x.id == id).FirstOrDefault();
                    db.Students.Remove(student);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
