using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ApplicationServices;
using WebSiteBanHang.Models;


namespace WebSiteBanHang.Controllers
{
    public class ThongKeController : Controller
    {
        QuanLyBanHangEntities1 db = new QuanLyBanHangEntities1();
        //
        // GET: /ThongKe/
        [HttpGet]
        public ActionResult ThongKe()
        {
            //
            ViewBag.PageView = HttpContext.Application["PageView"].ToString();
            ViewBag.Online = HttpContext.Application["Online"].ToString();
            return View();
        }
        [HttpGet]
        public JsonResult GetJsonData(int Year=2015)
        {
            var lstDonDatHang = db.DonDatHangs.Where(n=>n.NgayDat.Value.Year==Year).ToList();
            var list = new List<ThongKeDoanhThu>();
           
            if(lstDonDatHang.Count>0)
            {
                ThongKeDoanhThu tk;
                for (int i = 1; i <= 12; i++)
                {
                    tk = new ThongKeDoanhThu();
                    tk.Nam = Year;
                    tk.Thang = i;
                    var lstDoanhThu = lstDonDatHang.Where(n => n.NgayDat.Value.Month == i);
                    if (lstDonDatHang.Count() > 0)
                    {
                        tk.DoanhThu = 0;
                        foreach(var item in lstDoanhThu)
                        {
                            tk.DoanhThu += item.ChiTietDonDatHangs.Sum(n => n.SoLuong * n.DonGia).Value;
                     
                            tk.DoanhThu = 10000;
                        }
                    }
                    list.Add(tk);
                }
             }

         
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}