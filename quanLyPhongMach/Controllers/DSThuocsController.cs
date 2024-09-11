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
    public class DSThuocsController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: DSThuocs
        public ActionResult ThuocVatTu()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<LoaiThuoc> lt = db.LoaiThuocs.ToList();
            SelectList loaithuoc = new SelectList(lt, "IDLoai", "TenLoai");
            ViewBag.ltts = lt;

            List<DMKhoThuoc> kt = db.DMKhoThuocs.ToList();
            ViewBag.ktt = kt;



            List<DonViTinh> dvv = db.DonViTinhs.ToList();
            ViewBag.dvvv = dvv;
            SelectList dvt = new SelectList(dvv, "IDDonVi", "DonViThuoc");

            List<tb_HangSanXuat> hsx = db.tb_HangSanXuat.ToList();
            ViewBag.hsxx1 = hsx;
            SelectList hsxx = new SelectList(hsx, "MaHangSanXuat", "TenHangSanXuat");

            List<QuocGia> qg = db.QuocGias.ToList();
            ViewBag.qg1 = qg;
            SelectList qgg = new SelectList(qg, "MaQuocGia", "TenQuocGia");

            List<DSThuoc> dst = db.DSThuocs.ToList();

            List<NhaCungCap> nccc = db.NhaCungCaps.ToList();
            SelectList nsjs = new SelectList(nccc, "ID", "Ten");
            ViewBag.nhaucungcaps = nsjs;

            ViewBag.dst = dst;
            ViewBag.qgg = qgg;
            ViewBag.hsxx = hsxx;
            ViewBag.dvtt = dvt;
            ViewBag.ltt = loaithuoc;
            return View(db.DSThuocs.ToList());
        }
        

        // GET: DSThuocs/Details/5
        public ActionResult ChiTietToaThuocVatTu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuoc dSThuoc = db.DSThuocs.Find(id);
            if (dSThuoc == null)
            {
                return HttpNotFound();
            }
            return View(dSThuoc);
        }

        // GET: DSThuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DSThuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThuoc,TenThuoc,HoatChat,LoaiThuoc,DonVi,SoLuongTon,MaHangSanXuat,MaQuocGia,GhiChu")] DSThuoc dSThuoc)
        {
            if (ModelState.IsValid)
            {
                db.DSThuocs.Add(dSThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dSThuoc);
        }

        // GET: DSThuocs/Edit/5
        public ActionResult SuaThuocVatTu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuoc dSThuoc = db.DSThuocs.Find(id);
            if (dSThuoc == null)
            {
                return HttpNotFound();
            }
            return View(dSThuoc);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaThuocVatTu([Bind(Include = "MaThuoc,TenThuoc,HoatChat,LoaiThuoc,DonVi,SoLuongTon,MaHangSanXuat,MaQuocGia,GhiChu")] DSThuoc dSThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThuocVatTu");
            }
            return View(dSThuoc);
        }

        // GET: DSThuocs/Delete/5
        public ActionResult XoaVatTu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuoc dSThuoc = db.DSThuocs.Find(id);
            if (dSThuoc == null)
            {
                return HttpNotFound();
            }
            return View(dSThuoc);
        }

        // POST: DSThuocs/Delete/5
        [HttpPost, ActionName("XoaVatTu")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaVatTuConfirmed(string id)
        {
            DSThuoc dSThuoc = db.DSThuocs.Find(id);
            db.DSThuocs.Remove(dSThuoc);
            db.SaveChanges();
            return RedirectToAction("ThuocVatTu");
        }

        public ActionResult ToaThuocMau()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<DonViTinh> DVT = db.DonViTinhs.ToList();
            List<DonThuocMau> dtm = db.DonThuocMaus.ToList();
            List<DonThuoc> dt = db.DonThuocs.ToList();
            List<DSThuoc> dst = db.DSThuocs.ToList();
            // Truyền danh sách DonThuocMau vào view

            ViewBag.DVT = DVT;
            ViewBag.dtm = dtm;
            ViewBag.dt = dt;
            ViewBag.dst = dst;
            return View();
        }
       
        public ActionResult ThemToa(string IdDonThuoc, string TenDonThuoc)
        {
            try
            {
                // Tạo một đối tượng mới
                DonThuocMau newToa = new DonThuocMau { IdDonThuoc = IdDonThuoc, TenDonThuoc = TenDonThuoc };

                // Thêm đối tượng mới vào database
                db.DonThuocMaus.Add(newToa);
                db.SaveChanges();

                return Json(new { success = true, data = newToa });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
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
