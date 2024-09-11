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
    public class QuocGiasController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: QuocGias
        public ActionResult QuocGia()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.QuocGias.ToList());
        }

      

        // GET: QuocGias/Create
        public ActionResult ThemMoiQuocGia()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiQuocGia([Bind(Include = "MaQuocGia,TenQuocGia")] QuocGia quocGia)
        {
            if (string.IsNullOrEmpty(quocGia.TenQuocGia))
            {
                ModelState.AddModelError("", "Tên Quốc Gia không được để trống");
                return View(quocGia);
            }

            if (ModelState.IsValid)
            {
                db.QuocGias.Add(quocGia);
                db.SaveChanges();
                return RedirectToAction("QuocGia");
            }

            return View(quocGia);
        }

        // GET: QuocGias/Edit/5
        public ActionResult SuaQuocGia(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuocGia quocGia = db.QuocGias.Find(id);
            if (quocGia == null)
            {
                return HttpNotFound();
            }
            return View(quocGia);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaQuocGia([Bind(Include = "MaQuocGia,TenQuocGia")] QuocGia quocGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quocGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuocGia");
            }
            return View(quocGia);
        }

        // GET: QuocGias/Delete/5
        public ActionResult XoaQuocGia(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuocGia quocGia = db.QuocGias.Find(id);
            if (quocGia == null)
            {
                return HttpNotFound();
            }
            return View(quocGia);
        }

        // POST: QuocGias/Delete/5
        [HttpPost, ActionName("XoaQuocGia")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaQuocGiaConfirmed(string id)
        {
            QuocGia quocGia = db.QuocGias.Find(id);
            db.QuocGias.Remove(quocGia);
            db.SaveChanges();
            return RedirectToAction("QuocGia");
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
