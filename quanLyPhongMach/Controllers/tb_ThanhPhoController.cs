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
    public class tb_ThanhPhoController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_ThanhPho
        public ActionResult ThanhPho()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            return View(db.tb_ThanhPho.ToList());
        }

      
        // GET: tb_ThanhPho/Create
        public ActionResult ThemMoiThanhPho()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiThanhPho([Bind(Include = "MaThanhPho,TenThanhPho")] tb_ThanhPho tb_ThanhPho)
        {
            if (ModelState.IsValid)
            {
                db.tb_ThanhPho.Add(tb_ThanhPho);
                db.SaveChanges();
                return RedirectToAction("ThanhPho");
            }

            return View(tb_ThanhPho);
        }

        // GET: tb_ThanhPho/Edit/5
        public ActionResult SuaThanhPho(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ThanhPho tb_ThanhPho = db.tb_ThanhPho.Find(id);
            if (tb_ThanhPho == null)
            {
                return HttpNotFound();
            }
            return View(tb_ThanhPho);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaThanhPho([Bind(Include = "MaThanhPho,TenThanhPho")] tb_ThanhPho tb_ThanhPho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ThanhPho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThanhPho");
            }
            return View(tb_ThanhPho);
        }

        // GET: tb_ThanhPho/Delete/5
        public ActionResult XoaThanhPho(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ThanhPho tb_ThanhPho = db.tb_ThanhPho.Find(id);
            if (tb_ThanhPho == null)
            {
                return HttpNotFound();
            }
            return View(tb_ThanhPho);
        }

        // POST: tb_ThanhPho/Delete/5
        [HttpPost, ActionName("XoaThanhPho")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaThanhPhoConfirmed(int id)
        {
            tb_ThanhPho tb_ThanhPho = db.tb_ThanhPho.Find(id);
            db.tb_ThanhPho.Remove(tb_ThanhPho);
            db.SaveChanges();
            return RedirectToAction("ThanhPho");
        }


        public ActionResult ThanhPhoVaQuanHuyen()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            List<tb_ThanhPho> tp = db.tb_ThanhPho.ToList();
            SelectList thanhpho = new SelectList(tp, "MaThanhPho", "TenThanhPho");
            List<tb_QuanHuyen> qh = db.tb_QuanHuyen.ToList();
            ViewBag.tpp = thanhpho;
            ViewBag.qhh = qh;
            return View();
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
