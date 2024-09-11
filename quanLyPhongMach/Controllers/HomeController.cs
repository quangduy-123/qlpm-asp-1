using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace quanLyPhongMach.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {



            //nếu bằng null quay về đăng nhập
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {


            //check db
            using (mrtademoEntities db = new mrtademoEntities())
            {
                var taikhoan = db.NhanViens.FirstOrDefault(m => m.TaiKhoan.ToLower() == user.ToLower()
                                                        && m.MatKhauTC == password);



                //check code
                if (taikhoan != null)
                {

                    Session["user"] = taikhoan;
                    ViewBag.user = taikhoan;
                    return RedirectToAction("Index");
                }
                else
                {
                    // tb lỗi hay sài
                    TempData["error"] = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }
            }
        }


        public ActionResult DangXuat()
        {
            //xóa session

            Session.Remove("user");

            //Xóa session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("DangNhap");
        }


        //thongtintaikhoan

        mrtademoEntities db = new mrtademoEntities();
        public ActionResult ThongTinNguoiDung()
        {
            // Lấy thông tin người dùng từ phiên làm việc
            var user = Session["user"] as NhanVien;
            List<DonViSuDung> dv = db.DonViSuDungs.ToList();
            ViewBag.dv = dv;

            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                // Kiểm tra nếu người dùng muốn đổi mật khẩu
                if (Request.QueryString["ChangePassword"] == "true")
                {

                    return RedirectToAction("DoiMatKhau");
                }
                else
                {
                    // Trả về chế độ xem Index và truyền dữ liệu người dùng 
                    return View(user);
                }
            }
        }

        public ActionResult DoiMatKhau()
        {
            var user = Session["user"] as NhanVien;

            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }

            // Hiển thị form đổi mật khẩu và điền dữ liệu người dùng vào
            ViewBag.User = user;
            return View();
        }


        [HttpPost]
        public ActionResult DoiMatKhau(string oldPassword, string newPassword, string confirmPassword)
        {
            // Lấy thông tin người dùng từ Session
            var user = Session["user"] as NhanVien;

            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }

            // Kiểm tra xem mật khẩu cũ có khớp không
            if (user.MatKhauTC != oldPassword)
            {
                ModelState.AddModelError("oldPassword", "Mật khẩu cũ không đúng.");
                ViewBag.Message = "Đổi mật khẩu thất bại. Mật khẩu cũ không đúng.";
                return View();
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("confirmPassword", "Xác nhận mật khẩu không đúng.");
                ViewBag.Message = "Đổi mật khẩu thất bại. Xác nhận mật khẩu không đúng.";
                return View();
            }

            try
            {
                // Cập nhật mật khẩu mới của người dùng trong cơ sở dữ liệu
                user.MatKhauTC = newPassword;

                // Sử dụng đối tượng db để lưu thay đổi vào cơ sở dữ liệu
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Message = "Đổi mật khẩu thành công.";
                // Chuyển hướng về trang thông tin người dùng sau khi đổi mật khẩu thành công
                return RedirectToAction("ThongTinNguoiDung");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lưu vào cơ sở dữ liệu
                ViewBag.Message = "Đã xảy ra lỗi khi lưu mật khẩu mới: " + ex.Message;
                return View();
            }
        }




    }
}
