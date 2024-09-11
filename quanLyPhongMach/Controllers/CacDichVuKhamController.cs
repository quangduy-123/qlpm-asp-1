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
    public class CacDichVuKhamController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: CacDichVuKham
        public ActionResult CacDichVuKham()
        {
            //nếu bằng null quay về đăng nhập
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            else
            {
                return View(db.CacDichVuKhams.ToList());
            }
           
        }

      

        // GET: CacDichVuKham/ThemMoi
        public ActionResult ThemMoiDichVuKham()
        {
            List<CacDichVuKham> dv = db.CacDichVuKhams.ToList();
            ViewBag.cdvk = dv;
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiDichVuKham([Bind(Include = "ID,TenDV,ChiPhi,Chon")] CacDichVuKham cacDichVuKham)
        {
            if (ModelState.IsValid)
            {
                db.CacDichVuKhams.Add(cacDichVuKham);
                db.SaveChanges();
                return RedirectToAction("CacDichVuKham");
            }

            return View(cacDichVuKham);
        }

        // GET: CacDichVuKham/Edit/5
        public ActionResult SuaDichVuKham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacDichVuKham cacDichVuKham = db.CacDichVuKhams.Find(id);
            if (cacDichVuKham == null)
            {
                return HttpNotFound();
            }
            return View(cacDichVuKham);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDichVuKham([Bind(Include = "ID,TenDV,ChiPhi,Chon")] CacDichVuKham cacDichVuKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cacDichVuKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CacDichVuKham");
            }
            return View(cacDichVuKham);
        }

      
        public ActionResult XoaDichVu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacDichVuKham cacDichVuKham = db.CacDichVuKhams.Find(id);
            if (cacDichVuKham == null)
            {
                return HttpNotFound();
            }
            return View(cacDichVuKham);
        }

      
        [HttpPost, ActionName("XoaDichVu")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDichVuConfirmed(int id)
        {
            CacDichVuKham cacDichVuKham = db.CacDichVuKhams.Find(id);
            db.CacDichVuKhams.Remove(cacDichVuKham);
            db.SaveChanges();
            return RedirectToAction("CacDichVuKham");
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
