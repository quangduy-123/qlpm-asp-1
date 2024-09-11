using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        mrtademoEntities db = new mrtademoEntities();
        public ActionResult ThongKeBanThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<HoaDonBanThuoc> hd = db.HoaDonBanThuocs.ToList();
            ViewBag.hd = hd;
            return View();
        }

        public ActionResult ThongKeKhoThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<LoaiThuoc> lt = db.LoaiThuocs.ToList();
            ViewBag.ltt = lt;


            List<DonViTinh> dvt = db.DonViTinhs.ToList();
            ViewBag.dvt = dvt;


            List<DSThuoc> dstt = db.DSThuocs.ToList();
            ViewBag.dstt = dstt;


            List<DSThuoc2> dstts = db.DSThuoc2.ToList();
            ViewBag.dsttt = dstts;

            List<DMKhoThuoc2> ktt = db.DMKhoThuoc2.ToList();
            ViewBag.ktt = ktt;

            List<DMKhoThuoc> kt = db.DMKhoThuocs.ToList();
            ViewBag.kt = kt;
            return View();

        }


        public ActionResult ThuocHetHan()
        {


            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<LoaiThuoc> lt = db.LoaiThuocs.ToList();
            ViewBag.ltt = lt;


            List<DonViTinh> dvt = db.DonViTinhs.ToList();
            ViewBag.dvt = dvt;


            List<DSThuoc> dstt = db.DSThuocs.ToList();
            ViewBag.dstt = dstt;


            List<DSThuoc2> dstts = db.DSThuoc2.ToList();
            ViewBag.dsttt = dstts;

            List<DMKhoThuoc2> ktt = db.DMKhoThuoc2.ToList();
            ViewBag.ktt = ktt;

            List<DMKhoThuoc> kt = db.DMKhoThuocs.ToList();
            ViewBag.kt = kt;
            return View();


           
        }
        public ActionResult ThuocBanHet()
        {


            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];
            List<LoaiThuoc> lt = db.LoaiThuocs.ToList();
            ViewBag.ltt = lt;


            List<DonViTinh> dvt = db.DonViTinhs.ToList();
            ViewBag.dvt = dvt;


            List<DSThuoc> dstt = db.DSThuocs.ToList();
            ViewBag.dstt = dstt;


            List<DSThuoc2> dstts = db.DSThuoc2.ToList();
            ViewBag.dsttt = dstts;

            List<DMKhoThuoc2> ktt = db.DMKhoThuoc2.ToList();
            ViewBag.ktt = ktt;

            List<DMKhoThuoc> kt = db.DMKhoThuocs.ToList();
            ViewBag.kt = kt;
            return View();



        }

        public ActionResult ThongKeLaiBanThuoc()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            return View();
        }

        public ActionResult ThongKeThuKham()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            // Lấy thông tin nhân viên từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

            List<PhieuThuChiTiet> ohieuthuct = db.PhieuThuChiTiets.ToList();
            ViewBag.pt = ohieuthuct;

            List<NhanVien> nhanvien = db.NhanViens.ToList();
            ViewBag.nv = nhanvien;

            List<CacDichVuKham> nhanviens = db.CacDichVuKhams.ToList();
            ViewBag.dvs = nhanviens;

            return View();
        }



        public ActionResult ThongKeNhapXuat()
        {

            List<DMThuocDonGia> khothuoc = db.DMThuocDonGias.ToList();
            SelectList listtime = new SelectList(khothuoc, "MaThuoc", "NgayNhap");
            ViewBag.khothuocs1 = listtime;
            ViewBag.khothuocc1 = khothuoc;



            List<DSThuoc> tthuoc = db.DSThuocs.ToList();
            ViewBag.khothuoc123 = tthuoc;

            List<DonViTinh> dvt = db.DonViTinhs.ToList();
            ViewBag.donvitinh = dvt;

            return View();
        }
    }

    

}
