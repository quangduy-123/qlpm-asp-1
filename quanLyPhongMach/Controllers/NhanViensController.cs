using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class NhanViensController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: NhanViens


        public ActionResult PhanQuyenNhanVien()
        {
            // Kiểm tra quyền
            bool hasPermission = false;

            // Kiểm tra quyền
            using (mrtademoEntities db = new mrtademoEntities())
            {
                // Kích hoạt session
                if (HttpContext.Session["user"] == null)
                {
                    // Nếu không có thông tin nhân viên trong session, chuyển hướng đến trang đăng nhập
                    return RedirectToAction("DangNhap", "Home");
                }

                // Lấy thông tin nhân viên từ session
                NhanVien nvsseison = (NhanVien)HttpContext.Session["user"];

                // Truy vấn cơ sở dữ liệu để kiểm tra quyền
                var nhanVienDB = db.NhanViens.FirstOrDefault(nv => nv.MaNV == nvsseison.MaNV && nv.ChuyenMon == "Administrator");

                if (nhanVienDB == null)
                {
                    // Nếu không tìm thấy nhân viên trong cơ sở dữ liệu, chuyển hướng đến trang thông báo lỗi
                    return RedirectToAction("KhongCoQuyen", "BaoLoi");
                }
                else if (nhanVienDB.ChuyenMon != "Administrator")
                {
                    // Nếu nhân viên không có quyền Administrator, chuyển hướng đến trang thông báo lỗi quyền
                    return RedirectToAction("KhongCoQuyen", "BaoLoi");
                }
                else
                {
                    // Nếu nhân viên có quyền Administrator, gán biến hasPermission là true
                    hasPermission = true;
                }
            }

            // Nếu có quyền, tiếp tục thực thi
            if (hasPermission)
            {
                var nhanViens = db.NhanViens.Include(n => n.DonViSuDung).Include(n => n.NhanVienQuyen);
                return View(nhanViens.ToList());
            }
            else
            {
                // Nếu không có quyền, thực hiện chuyển hướng đến trang khác
                return RedirectToAction("KhongCoQuyen", "BaoLoi");
            }



        }

        // GET: NhanViens/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.DonVi = new SelectList(db.DonViSuDungs, "IDDonVi", "TenDonVi");
            ViewBag.MaNV = new SelectList(db.NhanVienQuyens, "MaNV", "Quyen");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,Phai,NgaySinh,DiaChi,DienThoai,ChuyenMon,NgoaiNgu,MucLuong,ChucVu,TaiKhoan,MatKhauTC,GhiChu,Hinh,DonVi")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    return RedirectToAction("PhanQuyenNhanVien");
                }
                catch (Exception ex)
                {

                    /* ModelState.AddModelError("","Có Lỗi Xảy Ra:" + ex.Message);*/
                }
            }

            ViewBag.DonVi = new SelectList(db.DonViSuDungs, "IDDonVi", "TenDonVi", nhanVien.DonVi);
            ViewBag.MaNV = new SelectList(db.NhanVienQuyens, "MaNV", "Quyen", nhanVien.MaNV);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonVi = new SelectList(db.DonViSuDungs, "IDDonVi", "TenDonVi", nhanVien.DonVi);
            ViewBag.MaNV = new SelectList(db.NhanVienQuyens, "MaNV", "Quyen", nhanVien.MaNV);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,Phai,NgaySinh,DiaChi,DienThoai,ChuyenMon,NgoaiNgu,MucLuong,ChucVu,TaiKhoan,MatKhauTC,GhiChu,Hinh,DonVi")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PhanQuyenNhanVien");
            }
            ViewBag.DonVi = new SelectList(db.DonViSuDungs, "IDDonVi", "TenDonVi", nhanVien.DonVi);
            ViewBag.MaNV = new SelectList(db.NhanVienQuyens, "MaNV", "Quyen", nhanVien.MaNV);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("PhanQuyenNhanVien");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult PhanQuyenNhanVienPratial()
        {
            List<NhanVienQuyen> nv = db.NhanVienQuyens.ToList();
            List<NhanVien> nvv = db.NhanViens.ToList();
            SelectList nvvv = new SelectList(nvv, "MaNV", "TenNV");
            ViewBag.nv = nvvv;

            List<TreeChucNang> cn = db.TreeChucNangs.ToList();
            ViewBag.cn = cn;
            return PartialView(cn);
        }
    }
}