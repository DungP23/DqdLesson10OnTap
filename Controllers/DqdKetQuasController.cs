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
    public class DqdKetQuasController : Controller
    {
        private DqdQlSvEntities1 db = new DqdQlSvEntities1();

        // GET: DqdKetQuas
        public ActionResult DqdIndex()
        {
            var ketQua = db.KetQua.Include(k => k.MonHoc).Include(k => k.SinhVien);
            return View(ketQua.ToList());
        }

        // GET: DqdKetQuas/Details/5
        public ActionResult DqdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQua.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // GET: DqdKetQuas/Create
        public ActionResult DqdCreate()
        {
            ViewBag.MaMh = new SelectList(db.MonHoc, "MaMh", "TenMh");
            ViewBag.MaSv = new SelectList(db.SinhVien, "MaSv", "HoSv");
            return View();
        }

        // POST: DqdKetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdCreate([Bind(Include = "MaSv,MaMh,Diem")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.KetQua.Add(ketQua);
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }

            ViewBag.MaMh = new SelectList(db.MonHoc, "MaMh", "TenMh", ketQua.MaMh);
            ViewBag.MaSv = new SelectList(db.SinhVien, "MaSv", "HoSv", ketQua.MaSv);
            return View(ketQua);
        }

        // GET: DqdKetQuas/Edit/5
        public ActionResult DqdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQua.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMh = new SelectList(db.MonHoc, "MaMh", "TenMh", ketQua.MaMh);
            ViewBag.MaSv = new SelectList(db.SinhVien, "MaSv", "HoSv", ketQua.MaSv);
            return View(ketQua);
        }

        // POST: DqdKetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdEdit([Bind(Include = "MaSv,MaMh,Diem")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DqdIndex");
            }
            ViewBag.MaMh = new SelectList(db.MonHoc, "MaMh", "TenMh", ketQua.MaMh);
            ViewBag.MaSv = new SelectList(db.SinhVien, "MaSv", "HoSv", ketQua.MaSv);
            return View(ketQua);
        }

        // GET: DqdKetQuas/Delete/5
        public ActionResult DqdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQua.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: DqdKetQuas/Delete/5
        [HttpPost, ActionName("DqdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KetQua ketQua = db.KetQua.Find(id);
            db.KetQua.Remove(ketQua);
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
