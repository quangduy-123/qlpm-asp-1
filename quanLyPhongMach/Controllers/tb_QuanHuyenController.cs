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
    public class tb_QuanHuyenController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_QuanHuyen
        public ActionResult QuanHuyen()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            return View(db.tb_QuanHuyen.ToList());
        }

       
        // GET: tb_QuanHuyen/Create
        public ActionResult ThemMoiQuanHuyen()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiQuanHuyen([Bind(Include = "MaQuanHuyen,TenQuanHuyen,MaThanhPho")] tb_QuanHuyen tb_QuanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.tb_QuanHuyen.Add(tb_QuanHuyen);
                db.SaveChanges();
                return RedirectToAction("QuanHuyen");
            }

            return View(tb_QuanHuyen);
        }

        // GET: tb_QuanHuyen/Edit/5
        public ActionResult SuaQuanHuyen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_QuanHuyen tb_QuanHuyen = db.tb_QuanHuyen.Find(id);
            if (tb_QuanHuyen == null)
            {
                return HttpNotFound();
            }
            return View(tb_QuanHuyen);
        }

        // POST: tb_QuanHuyen/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaQuanHuyen([Bind(Include = "MaQuanHuyen,TenQuanHuyen,MaThanhPho")] tb_QuanHuyen tb_QuanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_QuanHuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanHuyen");
            }
            return View(tb_QuanHuyen);
        }

        // GET: tb_QuanHuyen/Delete/5
        public ActionResult XoaQuanHuyen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_QuanHuyen tb_QuanHuyen = db.tb_QuanHuyen.Find(id);
            if (tb_QuanHuyen == null)
            {
                return HttpNotFound();
            }
            return View(tb_QuanHuyen);
        }

        // POST: tb_QuanHuyen/Delete/5
        [HttpPost, ActionName("XoaQuanHuyen")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaQuanHuyenConfirmed(int id)
        {
            tb_QuanHuyen tb_QuanHuyen = db.tb_QuanHuyen.Find(id);
            db.tb_QuanHuyen.Remove(tb_QuanHuyen);
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
