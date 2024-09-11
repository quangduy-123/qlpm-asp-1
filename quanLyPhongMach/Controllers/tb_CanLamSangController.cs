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
    public class tb_CanLamSangController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_CanLamSang
        public ActionResult CanLamSang()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.tb_CanLamSang.ToList());
        }

        
        // GET: tb_CanLamSang/Create
        public ActionResult ThemMoiCanLamSang()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiCanLamSang([Bind(Include = "MaCanLamSang,TenCanLamSang")] tb_CanLamSang tb_CanLamSang)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tb_CanLamSang.Add(tb_CanLamSang);
                    db.SaveChanges();
                    return RedirectToAction("CanLamSang");
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    ModelState.AddModelError("", "Lỗi khi thêm mới cận lâm sàng: " + ex.Message);
                }
            }
            return View(tb_CanLamSang);
        }


        // GET: tb_CanLamSang/Edit/5
        public ActionResult SuaCanLamSang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_CanLamSang tb_CanLamSang = db.tb_CanLamSang.Find(id);
            if (tb_CanLamSang == null)
            {
                return HttpNotFound();
            }
            return View(tb_CanLamSang);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaCanLamSang([Bind(Include = "MaCanLamSang,TenCanLamSang")] tb_CanLamSang tb_CanLamSang)
        {
            if (string.IsNullOrEmpty(tb_CanLamSang.TenCanLamSang))
            {
                ModelState.AddModelError("", "Tên Cận Lâm Sàng không được để trống");
                return View(tb_CanLamSang);
            }

         

            if (ModelState.IsValid)
            {
                db.Entry(tb_CanLamSang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CanLamSang");
            }
            return View(tb_CanLamSang);
        }

        // GET: tb_CanLamSang/Delete/5
        public ActionResult XoaCanLamSang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_CanLamSang tb_CanLamSang = db.tb_CanLamSang.Find(id);
            if (tb_CanLamSang == null)
            {
                return HttpNotFound();
            }
            return View(tb_CanLamSang);
        }

        // POST: tb_CanLamSang/Delete/5
        [HttpPost, ActionName("XoaCanLamSang")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaCanLamSangConfirmed(int id)
        {
            tb_CanLamSang tb_CanLamSang = db.tb_CanLamSang.Find(id);
            db.tb_CanLamSang.Remove(tb_CanLamSang);
            db.SaveChanges();
            return RedirectToAction("CanLamSang");
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
