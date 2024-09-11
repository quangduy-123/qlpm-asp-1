using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanLyPhongMach.Controllers
{
    public class BaoLoiController : Controller
    {
        // GET: BaoLoi
        public ActionResult KhongCoQuyen()
        {
            return View();
        }

        public ActionResult KhongTimThayDonVi()
        {
            return View();
        }
    }
}