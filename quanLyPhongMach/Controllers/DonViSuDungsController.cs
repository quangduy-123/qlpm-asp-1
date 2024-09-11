using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using quanLyPhongMach.Models;

namespace quanLyPhongMach.Controllers
{
    public class DonViSuDungsController : Controller
    {
        private mrtademoEntities db = new mrtademoEntities();

        // GET: DonViSuDungs
        public ActionResult DonViSuDung()
        {
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
                return View(db.DonViSuDungs.ToList());
            }
            else
            {
                // Nếu không có quyền, thực hiện chuyển hướng đến trang khác
                return RedirectToAction("KhongCoQuyen", "BaoLoi");
            }

        }


        public ActionResult ThemMoiDonVi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiDonVi([Bind(Include = "IDDonVi,TenDonVi,TenPM,DiaChiPM,DienThoaiPM,FaxPM,EmailPM,MaSoThuePM")] DonViSuDung donViSuDung)
        {
            if (ModelState.IsValid)
            {
                db.DonViSuDungs.Add(donViSuDung);
                db.SaveChanges();
                return RedirectToAction("DonViSuDung");
            }

            return View(donViSuDung);
        }

        
        public ActionResult SuaDonVi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViSuDung donViSuDung = db.DonViSuDungs.Find(id);
            if (donViSuDung == null)
            {
                return HttpNotFound();
            }
            return View(donViSuDung);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SuaDonVi([Bind(Include = "IDDonVi,TenDonVi,TenPM,DiaChiPM,DienThoaiPM,FaxPM,EmailPM,MaSoThuePM")] DonViSuDung donViSuDung)
        {
            if (ModelState.IsValid)
            {
                
                    db.Entry(donViSuDung).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DonViSuDung");
                
                
            }
            return View(donViSuDung);
        }






        public ActionResult XoaDonVi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViSuDung donViSuDung = db.DonViSuDungs.Find(id);
            if (donViSuDung == null)
            {
                return HttpNotFound();
            }
            return View(donViSuDung);
        }

      
        [HttpPost, ActionName("XoaDonVi")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDonViConfirmed(int id)
        {
            DonViSuDung donViSuDung = db.DonViSuDungs.Find(id);
            db.DonViSuDungs.Remove(donViSuDung);
            db.SaveChanges();
            return RedirectToAction("DonViSuDung");
        }


        public ActionResult ThongTinPhongMach()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            // Lấy thông tin nhân viên từ session
            NhanVien nvsseison = (NhanVien)HttpContext.Session["user"];

            using (mrtademoEntities db = new mrtademoEntities())
            {
                // Truy vấn cơ sở dữ liệu để lấy thông tin phòng mạch cho đơn vị của nhân viên
                var phongMach = db.DonViSuDungs.FirstOrDefault(pm => pm.IDDonVi == nvsseison.DonVi);

                if (phongMach == null)
                {
                    
                    return RedirectToAction("KhongCoQuyen", "BaoLoi");
                }

                return View(phongMach);
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
