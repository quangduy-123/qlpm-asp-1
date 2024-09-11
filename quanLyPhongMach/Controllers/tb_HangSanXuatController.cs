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
    public class tb_HangSanXuatController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_HangSanXuat
        public ActionResult HangSanXuat()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            return View(db.tb_HangSanXuat.ToList());
        }

        
      

        // GET: tb_HangSanXuat/Create
        public ActionResult ThemMoiHangSanXuat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiHangSanXuat([Bind(Include = "MaHangSanXuat,TenHangSanXuat,GhiChu")] tb_HangSanXuat tb_HangSanXuat)
        {
            if (string.IsNullOrEmpty(tb_HangSanXuat.TenHangSanXuat))
            {
                ModelState.AddModelError("", "Tên Hãng Sản Xuất không được để trống");
                return View(tb_HangSanXuat);
            }

            if (string.IsNullOrEmpty(tb_HangSanXuat.GhiChu))
            {
                ModelState.AddModelError("", "Ghi Chú  không được để trống");
                return View(tb_HangSanXuat);
            }

            if (ModelState.IsValid)
            {
                db.tb_HangSanXuat.Add(tb_HangSanXuat);
                db.SaveChanges();
                return RedirectToAction("HangSanXuat");
            }

            return View(tb_HangSanXuat);
        }

        // GET: tb_HangSanXuat/Edit/5
        public ActionResult SuaHangSanXuat(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HangSanXuat tb_HangSanXuat = db.tb_HangSanXuat.Find(id);
            if (tb_HangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_HangSanXuat);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaHangSanXuat([Bind(Include = "MaHangSanXuat,TenHangSanXuat,GhiChu")] tb_HangSanXuat tb_HangSanXuat)
        {
            if (string.IsNullOrEmpty(tb_HangSanXuat.TenHangSanXuat))
            {
                ModelState.AddModelError("", "Tên Hãng Sản Xuất không được để trống");
                return View(tb_HangSanXuat);
            }

            if (string.IsNullOrEmpty(tb_HangSanXuat.GhiChu))
            {
                ModelState.AddModelError("", "Ghi Chú  không được để trống");
                return View(tb_HangSanXuat);
            }
            if (ModelState.IsValid)
            {
                db.Entry(tb_HangSanXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_HangSanXuat);
        }

        // GET: tb_HangSanXuat/Delete/5
        public ActionResult XoaHangSanXuat(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HangSanXuat tb_HangSanXuat = db.tb_HangSanXuat.Find(id);
            if (tb_HangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_HangSanXuat);
        }

        // POST: tb_HangSanXuat/Delete/5
        [HttpPost, ActionName("XoaHangSanXuat")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaHangSanXuatConfirmed(string id)
        {
            tb_HangSanXuat tb_HangSanXuat = db.tb_HangSanXuat.Find(id);
            db.tb_HangSanXuat.Remove(tb_HangSanXuat);
            db.SaveChanges();
            return RedirectToAction("Index");
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
