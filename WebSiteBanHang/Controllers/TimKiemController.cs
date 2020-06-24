using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
using PagedList;

namespace WebSiteBanHang.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        
            
        }
        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTuKhoa)
        {
            //Gọi về hàm get tìm kiếm
            return RedirectToAction("KQTimKiem", new {@sTuKhoa=sTuKhoa});
        }
        public ActionResult KQTimKiemPartial(string sTuKhoa)
        {
            //tìm kiếm theo ten sản phẩm
            var lstSP = db.SanPhams.Where(n => n.TenSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return PartialView(lstSP.OrderBy(n=>n.DonGia));
        }
     
	}
}