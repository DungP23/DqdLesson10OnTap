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
    public class DqdSinhViensController : Controller
    {
        private DqdQlSvEntities1 db = new DqdQlSvEntities1();

        // GET: DqdSinhViens
        public ActionResult DqdIndex()
        {
            var sinhVien = db.SinhVien.Include(s => s.Khoa);
            return View(sinhVien.ToList());
        }

        // GET: DqdSinhViens/Details/5
        public ActionResult DqdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: DqdSinhViens/Create
        public ActionResult DqdCreate()
        {
            ViewBag.MaKh = new SelectList(db.Khoa, "MaKh", "TenKhoa");
            return View();
        }

        // POST: DqdSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdCreate([Bind(Include = "MaSv,HoSv,TenSv,Phai,NgaySinh,NoiSinh,MaKh,HocBong,DiemTb")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhVien.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }

            ViewBag.MaKh = new SelectList(db.Khoa, "MaKh", "TenKhoa", sinhVien.MaKh);
            return View(sinhVien);
        }

        // GET: DqdSinhViens/Edit/5
        public ActionResult DqdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKh = new SelectList(db.Khoa, "MaKh", "TenKhoa", sinhVien.MaKh);
            return View(sinhVien);
        }

        // POST: DqdSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdEdit([Bind(Include = "MaSv,HoSv,TenSv,Phai,NgaySinh,NoiSinh,MaKh,HocBong,DiemTb")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }
            ViewBag.MaKh = new SelectList(db.Khoa, "MaKh", "TenKhoa", sinhVien.MaKh);
            return View(sinhVien);
        }

        // GET: DqdSinhViens/Delete/5
        public ActionResult DqdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: DqdSinhViens/Delete/5
        [HttpPost, ActionName("DqdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhVien.Find(id);
            db.SinhVien.Remove(sinhVien);
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
