using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System_OPL.Models;

namespace System_OPL.Controllers
{
    public class TestController : BaseController
    {

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var tests = context.Tests.Include(t => t.Object).Include(t => t.Doctors).Include(t => t.Nurses);
            return View(tests.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.ObjectId = new SelectList(context.Patients, "Id", "Name");
            ViewBag.DoctorId = new SelectList(context.Doctors, "Id", "UserName");
            ViewBag.NurseId = new SelectList(context.Nurses, "Id", "UserName");
            return View();
        }



        [HttpPost]
        public ActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                context.Tests.Add(test);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectId = new SelectList(context.Patients, "Id", "Name", test.ObjectId);
            ViewBag.DoctorId = new SelectList(context.Doctors, "Id", "UserName", test.DoctorId);
            ViewBag.NurseId = new SelectList(context.Nurses, "Id", "UserName", test.NurseId);
            return View(test);
        }



        public ActionResult Edit(int id = 0)
        {
            Test test = context.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectId = new SelectList(context.Patients, "Id", "Name", test.ObjectId);
            ViewBag.DoctorId = new SelectList(context.Doctors, "Id", "UserName", test.DoctorId);
            ViewBag.NurseId = new SelectList(context.Nurses, "Id", "UserName", test.NurseId);
            return View(test);
        }

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            if (ModelState.IsValid)
            {
                context.Entry(test).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectId = new SelectList(context.Patients, "Id", "Name", test.ObjectId);
            ViewBag.DoctorId = new SelectList(context.Doctors, "Id", "UserName", test.DoctorId);
            ViewBag.NurseId = new SelectList(context.Nurses, "Id", "UserName", test.NurseId);
            return View(test);
        }

        public ActionResult Delete(int id = 0)
        {
            Test test = context.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = context.Tests.Find(id);
            context.Tests.Remove(test);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}