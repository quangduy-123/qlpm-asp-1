using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class HeThongController : Controller
    {
        mrtademoEntities db = new mrtademoEntities();
        // GET: HeThong

        public ActionResult NguoiDung(string searchQuery)
        {
            using (mrtademoEntities db = new mrtademoEntities())
            {
                if (HttpContext.Session["user"] == null)
                {
                    return RedirectToAction("DangNhap", "Home");
                }

                NhanVien nvsseison = (NhanVien)HttpContext.Session["user"];

                var danhSachNhanVien = db.NhanViens.ToList();
                ViewBag.nv = danhSachNhanVien;
                // Tạo một danh sách mới để lưu kết quả tìm kiếm
                var ketQuaTimKiem = danhSachNhanVien;

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Thực hiện tìm kiếm theo TenNV
                    ketQuaTimKiem = danhSachNhanVien.Where(nv => nv.TenNV.Contains(searchQuery)).ToList();
                }

                List<DonViSuDung> dv = db.DonViSuDungs.ToList();
                ViewBag.dv = dv;
                // Truyền danh sách kết quả tìm kiếm vào view
                return View(ketQuaTimKiem);
            }
        }


        public ActionResult YeuCauHeThong()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<YeuCauHT> ychtt = db.YeuCauHTs.ToList();
            return View(db.YeuCauHTs.ToList());
        }

       
        

    }
}