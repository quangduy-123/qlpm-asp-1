using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class ChucNangController : Controller
    {
        // GET: ChucNang
        mrtademoEntities db = new mrtademoEntities();
        public ActionResult KhamBenh()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<NhanVien> nv = db.NhanViens.ToList();
            SelectList nvv = new SelectList(nv, "MaNV", "TenNV");
            ViewBag.nv = nvv;
            ViewBag.nvv = nv;

            List<HoSoBN> hsbnss = db.HoSoBNs.ToList();
            SelectList bn = new SelectList(hsbnss, "MaHS", "Phai");
            ViewBag.bnn = bn;
            ViewBag.hsbns = hsbnss;
            return View();
        }
        public ActionResult DanhSachBenhNhan()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<NhanVien> nv = db.NhanViens.ToList();
            SelectList nvv = new SelectList(nv, "MaNV", "TenNV");
            ViewBag.nv = nvv;
            ViewBag.nvv = nv;

            List<HoSoBN> hsbnss = db.HoSoBNs.ToList();
            SelectList bn = new SelectList(hsbnss, "MaHS", "Phai");
            ViewBag.bnn = bn;
            ViewBag.hsbns = hsbnss;
            return View();
        }
        public ActionResult ThemBenhNhan()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<NhanVien> nv = db.NhanViens.ToList();
            SelectList nvv = new SelectList(nv, "MaNV", "TenNV");
            ViewBag.nv = nvv;
            ViewBag.nvv = nv;

            List<HoSoBN> hsbn = db.HoSoBNs.ToList();
            SelectList bn = new SelectList(hsbn, "MaHS", "Phai");
            ViewBag.bn = bn;
            ViewBag.hsbn = hsbn;

            return View();
        }

        public ActionResult LichSuKham()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View();
        }

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

        public ActionResult NhapThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<ChungTuNhapXuat> nx = db.ChungTuNhapXuats.ToList();
            ViewBag.nx = nx;

            return View();
        }

        public ActionResult BanThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<ChungTuNhapXuat> pks = db.ChungTuNhapXuats.ToList();
            ViewBag.pkk = pks;

            List<PhieuKham> pk = db.PhieuKhams.ToList();
            ViewBag.pk = pk;

            return View();
        }

        public ActionResult ChungTuXuat()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View();
        }


        public ActionResult ChoKham()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View();
        }

        public ActionResult DaKham()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View();
        }

        public ActionResult HuyKham()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            return View();
        }

        public ActionResult LichHen()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<HoSoBN> bn = db.HoSoBNs.ToList();
            SelectList bnn = new SelectList(bn, "MaHS", "HoTen");
            ViewBag.bn = bnn;

            List<NhanVien> nv = db.NhanViens.ToList();
            SelectList nvv = new SelectList(nv, "MaNV", "TenNV");
            ViewBag.nvv = nvv;


            return View();
        }

        public ActionResult HoSoBenhNhan()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<NhanVien> nv = db.NhanViens.ToList();
            SelectList nvv = new SelectList(nv, "MaNV", "TenNV");
            ViewBag.nv = nvv;
            ViewBag.nvv = nv;

            List<HoSoBN> hsbns = db.HoSoBNs.ToList();
            SelectList bn = new SelectList(hsbns, "MaHS", "Phai");
            ViewBag.bn = bn;
            ViewBag.hsbns = hsbns;
            return View();
        }
        public ActionResult TongHop()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<PhieuHen> ph = db.PhieuHens.ToList();
            ViewBag.ph = ph;

            List<HoSoBN> bn = db.HoSoBNs.ToList();
            ViewBag.bn = bn;

            List<NhanVien> nv = db.NhanViens.ToList();
            ViewBag.nv = nv;


            return View();
        }
    }
}