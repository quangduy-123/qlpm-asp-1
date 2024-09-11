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
    public class tb_ChiDinhController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_ChiDinh
        public ActionResult ChiDinh()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.tb_ChiDinh.ToList());
        }

        // GET: tb_ChiDinh/Details/5
        public ActionResult ChiTietChiDinh(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChiDinh tb_ChiDinh = db.tb_ChiDinh.Find(id);
            if (tb_ChiDinh == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChiDinh);
        }

        // GET: tb_ChiDinh/Create
        public ActionResult ThemMoiChiDinh()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiChiDinh([Bind(Include = "MaChiDinh,TenChiDinh,DonGia,GhiChu")] tb_ChiDinh tb_ChiDinh1)
        {

            if (string.IsNullOrEmpty(tb_ChiDinh1.TenChiDinh))
            {
                ModelState.AddModelError("", "Tên Chỉ Định không được để trống");
                return View(tb_ChiDinh1);
            }

            if (ModelState.IsValid)
            {
                db.tb_ChiDinh.Add(tb_ChiDinh1);
                db.SaveChanges();
                return RedirectToAction("ChiDinh");
            }

            return View(tb_ChiDinh1);
        }

        // GET: tb_ChiDinh/Edit/5
        public ActionResult SuaChiDinh(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChiDinh tb_ChiDinh = db.tb_ChiDinh.Find(id);
            if (tb_ChiDinh == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChiDinh);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaChiDinh([Bind(Include = "MaChiDinh,TenChiDinh,DonGia,GhiChu")] tb_ChiDinh tb_ChiDinh1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ChiDinh1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChiDinh");
            }
            return View(tb_ChiDinh1);
        }

        // GET: tb_ChiDinh/Delete/5
        public ActionResult XoaChiDinh(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChiDinh tb_ChiDinh = db.tb_ChiDinh.Find(id);
            if (tb_ChiDinh == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChiDinh);
        }

       
        [HttpPost, ActionName("XoaChiDinh")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaChiDinhConfirmed(int id)
        {
            tb_ChiDinh tb_ChiDinh = db.tb_ChiDinh.Find(id);
            db.tb_ChiDinh.Remove(tb_ChiDinh);
            db.SaveChanges();
            return RedirectToAction("ChiDinh");
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
