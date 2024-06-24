using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DqdLesson10.Models;

namespace DqdLesson10.Controllers
{
    public class DqdKhoasController : Controller
    {
        private DqdQlSvEntities1 db = new DqdQlSvEntities1();

        // GET: DqdKhoas
        public ActionResult DqdIndex()
        {
            return View(db.Khoa.ToList());
        }

        // GET: DqdKhoas/Details/5
        public ActionResult DqdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // GET: DqdKhoas/Create
        public ActionResult DqdCreate()
        {
            return View();
        }

        // POST: DqdKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdCreate([Bind(Include = "MaKh,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Khoa.Add(khoa);
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }

            return View(khoa);
        }

        // GET: DqdKhoas/Edit/5
        public ActionResult DqdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: DqdKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdEdit([Bind(Include = "MaKh,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }
            return View(khoa);
        }

        // GET: DqdKhoas/Delete/5
        public ActionResult DqdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: DqdKhoas/Delete/5
        [HttpPost, ActionName("DqdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khoa khoa = db.Khoa.Find(id);
            db.Khoa.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("DqdIndex");
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
