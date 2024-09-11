using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quanLyPhongMach.Models;

namespace quanLyPhongMach.Controllers
{
    public class NhaCungCapsController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: NhaCungCaps
        public ActionResult NhaCungCap()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.NhaCungCaps.ToList());
        }

       
        // GET: NhaCungCaps/Create
        public ActionResult ThemMoiNhaCungCap()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiNhaCungCap([Bind(Include = "ID,Ten")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                db.NhaCungCaps.Add(nhaCungCap);
                db.SaveChanges();
                return RedirectToAction("NhaCungCap");
            }

            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Edit/5
        public ActionResult SuaNhaCungCap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNhaCungCap([Bind(Include = "ID,Ten")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaCungCap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NhaCungCap");
            }
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Delete/5
        public ActionResult XoaNhaCungCap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Delete/5
        [HttpPost, ActionName("XoaNhaCungCap")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaNhaCungCapConfirmed(int id)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            db.NhaCungCaps.Remove(nhaCungCap);
            db.SaveChanges();
            return RedirectToAction("NhaCungCap");
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
