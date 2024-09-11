using quanLyPhongMach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class GiaoDienController : Controller
    {
        // GET: GiaoDien
        public ActionResult Footer()
        {
            if (HttpContext.Session["user"] == null)
            {
                return PartialView(); // Trả về footer mặc định nếu không có người dùng đăng nhập
            }

            // Lấy thông tin người dùng từ session
            NhanVien nvsSession = (NhanVien)HttpContext.Session["user"];

           
            string chaoMungMessage = "Xin chào Bác Sĩ " + nvsSession.TenNV;

            
            ViewBag.ChaoMungMessage = chaoMungMessage;

            return PartialView();
        }



        public ActionResult Menu()
        {

            return PartialView();
        }
    }
}