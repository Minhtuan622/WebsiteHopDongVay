using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHopDongVay.Models;

namespace WebsiteHopDongVay.Controllers
{
    public class GiayBaoNhanLaiVayController : Controller
    {
        private static bool isEdit = false;
        
        // GET: GiayBaoNhanLaiVay
        [HttpGet]
        public ActionResult Index()
        {
            List<HDV_GBNLV> list = new dbQuanLyHopDongVayEntities().HDV_GBNLV.ToList<HDV_GBNLV>();
            ViewData["ds_gbnlv"] = list;
            return View();
        }

        // thêm dữ liệu
        [HttpPost]
        public ActionResult Index(HDV_GBNLV X)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            if(!isEdit)
                db.HDV_GBNLV.Add(X);
            else
            {
                HDV_GBNLV y = db.HDV_GBNLV.Find(X.GBNLV_SO);
                y.GBNLV_NGAY = X.GBNLV_NGAY;
                y.KUGN_SO = X.KUGN_SO;
                y.MSLNT = X.MSLNT;
                y.TYGIA = X.TYGIA;
                y.TIENLAI = X.TIENLAI;
                y.TIENLAIND = X.TIENLAIND;
                isEdit = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["ds_gbnlv"] = db.HDV_GBNLV.ToList<HDV_GBNLV>();
            return View();
        }

        // xóa dữ liệu
        [HttpPost]
        public ActionResult Delete(string giaybao_xoa)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GBNLV x = db.HDV_GBNLV.Find(giaybao_xoa);
            db.HDV_GBNLV.Remove(x);
            db.SaveChanges();
            ViewData["ds_gbnlv"] = db.HDV_GBNLV.ToList<HDV_GBNLV>();
            return View("Index");
        }

        // sửa dữ liệu
        [HttpPost]
        public ActionResult Edit(string giaybao_sua)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GBNLV X = db.HDV_GBNLV.Find(giaybao_sua);
            isEdit = true;
            ViewData["ds_gbnlv"] = db.HDV_GBNLV.ToList<HDV_GBNLV>();
            return View("Index", X);
        }
    }
}