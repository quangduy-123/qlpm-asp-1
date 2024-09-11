using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class ThanhToanDichVuController : Controller
    {
        // GET: ThanhToanDichVu
        mrtademoEntities db = new mrtademoEntities();
        public ActionResult ThanhToanDichVu()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<NhanVien> nv = db.NhanViens.ToList();
            ViewBag.nvv = nv;

            List<PhieuKham> pk = db.PhieuKhams.ToList();
            ViewBag.pk = pk;
            return View();
        }

        public ActionResult DanhSachBenhNhanDaKham()
        {

            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<NhanVien> nv = db.NhanViens.ToList();
            ViewBag.nvv = nv;

            List<PhieuKham> pk = db.PhieuKhams.ToList();
            ViewBag.pk = pk;
            return View();
        }
    }
}