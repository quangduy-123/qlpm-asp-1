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
    public class DonViTinhsController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: DonViTinhs
        public ActionResult DonViTinh()
        {

            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            return View(db.DonViTinhs.ToList());
        }

        // GET: DonViTinhs/Details/5
      
        // GET: DonViTinhs/Create
        public ActionResult ThemMoiDonViTinh()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiDonViTinh([Bind(Include = "RowID,IDDonVi,DonViThuoc")] DonViTinh donViTinh)
        {
            if (string.IsNullOrEmpty(donViTinh.DonViThuoc))
            {
                ModelState.AddModelError("", "Đơn Vị Tín không được để trống");
                return View(donViTinh);
            }

            if (donViTinh.RowID == null)
            {
                ModelState.AddModelError("", "Row không được để trống");
                return View(donViTinh);
            }

            if (ModelState.IsValid)
            {
                db.DonViTinhs.Add(donViTinh);
                db.SaveChanges();
                return RedirectToAction("DonViTinh");
            }

            return View(donViTinh);
        }

        // GET: DonViTinhs/Edit/5
        public ActionResult SuaDonViTinh(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDonViTinh([Bind(Include = "RowID,IDDonVi,DonViThuoc")] DonViTinh donViTinh)
        {
            if (string.IsNullOrEmpty(donViTinh.DonViThuoc))
            {
                ModelState.AddModelError("", "Đơn Vị Tín không được để trống");
                return View(donViTinh);
            }

            if (donViTinh.RowID == null)
            {
                ModelState.AddModelError("", "Row không được để trống");
                return View(donViTinh);
            }
            if (ModelState.IsValid)
            {
                db.Entry(donViTinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DonViTinh");
            }
            return View(donViTinh);
        }

        // GET: DonViTinhs/Delete/5
        public ActionResult XoaDonViTinh(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // POST: DonViTinhs/Delete/5
        [HttpPost, ActionName("XoaDonViTinh")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDonViTinhConfirmed(string id)
        {
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            db.DonViTinhs.Remove(donViTinh);
            db.SaveChanges();
            return RedirectToAction("DonViTinh");
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
