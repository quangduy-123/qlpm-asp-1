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
    public class tb_ChanDoanController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: tb_ChanDoan
        public ActionResult ChanDoan()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View(db.tb_ChanDoan.ToList());
        }

     

        // GET: tb_ChanDoan/Create
        public ActionResult ThemMoiChanDoan()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiChanDoan([Bind(Include = "MaChanDoan,TenChanDoan")] tb_ChanDoan tb_ChanDoan)
        {

            if (string.IsNullOrEmpty(tb_ChanDoan.TenChanDoan))
            {
                ModelState.AddModelError("", "Tên Chẩn Đoán không được để trống");
                return View(tb_ChanDoan);
            }
            if (ModelState.IsValid)
            {
                db.tb_ChanDoan.Add(tb_ChanDoan);
                db.SaveChanges();
                return RedirectToAction("ChanDoan");
            }

            return View(tb_ChanDoan);
        }


        // Controller Action for handling the search
        public ActionResult Search(string searchString)
        {

            var data = db.tb_ChanDoan.ToList();

         
            var filteredData = data.Where(item => item.TenChanDoan.Contains(searchString)).ToList();

          
            return View(filteredData);
        }
        // GET: tb_ChanDoan/Edit/5
        public ActionResult SuaChanDoan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChanDoan tb_ChanDoan = db.tb_ChanDoan.Find(id);
            if (tb_ChanDoan == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChanDoan);
        }

        // POST: tb_ChanDoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaChanDoan([Bind(Include = "MaChanDoan,TenChanDoan")] tb_ChanDoan tb_ChanDoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ChanDoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChanDoan");
            }
            return View(tb_ChanDoan);
        }

        // GET: tb_ChanDoan/Delete/5
        public ActionResult XoaChanDoan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChanDoan tb_ChanDoan = db.tb_ChanDoan.Find(id);
            if (tb_ChanDoan == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChanDoan);
        }

        // POST: tb_ChanDoan/Delete/5
        [HttpPost, ActionName("XoaChanDoan")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaChanDoanConfirmed(int id)
        {
            tb_ChanDoan tb_ChanDoan = db.tb_ChanDoan.Find(id);
            db.tb_ChanDoan.Remove(tb_ChanDoan);
            db.SaveChanges();
            return RedirectToAction("ChanDoan");
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
