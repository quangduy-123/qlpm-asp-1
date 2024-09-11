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
    public class LoaiThuocsController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: LoaiThuocs
        public ActionResult LoaiThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.LoaiThuocs.ToList());
        }



        // GET: LoaiThuocs/Create
        public ActionResult ThemMoiLoaiThuoc()
        {
            return View(new LoaiThuoc());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiLoaiThuoc(LoaiThuoc loaiThuoc)
        {
            if (string.IsNullOrEmpty(loaiThuoc.TenLoai))
            {
                ModelState.AddModelError("", "Tên loại không được để trống");
                return View(loaiThuoc);
            }

            if (string.IsNullOrEmpty(loaiThuoc.GhiChu))
            {
                ModelState.AddModelError("", "Ghi Chú không được để trống");
                return View(loaiThuoc);
            }

            using (var db = new mrtademoEntities())
            {
                db.LoaiThuocs.Add(loaiThuoc);
                db.SaveChanges();
            }

            if (loaiThuoc.IDLoai > 0)
            {
                return RedirectToAction("LoaiThuoc");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi Không Lưu Được Vào Data");
                return View(loaiThuoc);
            }
        }


        // GET: LoaiThuocs/Edit/5
        public ActionResult SuaLoaiThuoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuoc loaiThuoc = db.LoaiThuocs.Find(id);
            if (loaiThuoc == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuoc);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaLoaiThuoc([Bind(Include = "IDLoai,TenLoai,GhiChu")] LoaiThuoc loaiThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoaiThuoc");
            }
            return View(loaiThuoc);
        }

        // GET: LoaiThuocs/Delete/5
        public ActionResult XoaLoaiThuoc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuoc loaiThuoc = db.LoaiThuocs.Find(id);
            if (loaiThuoc == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuoc);
        }

        // POST: LoaiThuocs/Delete/5
        [HttpPost, ActionName("XoaLoaiThuoc")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiThuoc loaiThuoc = db.LoaiThuocs.Find(id);
            db.LoaiThuocs.Remove(loaiThuoc);
            db.SaveChanges();
            return RedirectToAction("LoaiThuoc");
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
