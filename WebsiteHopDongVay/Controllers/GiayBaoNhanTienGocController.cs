using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHopDongVay.Models;

namespace WebsiteHopDongVay.Controllers
{
    public class GiayBaoNhanTienGocController : Controller
    {
        private static bool isEdit = false;

        // GET: GiayBaoNhanLaiVay
        [HttpGet]
        public ActionResult Index()
        {
            List<HDV_GBNNG> list = new dbQuanLyHopDongVayEntities().HDV_GBNNG.ToList<HDV_GBNNG>();
            ViewData["ds_gbnng"] = list;
            return View();
        }

        // thêm dữ liệu
        [HttpPost]
        public ActionResult Index(HDV_GBNNG X)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            if (!isEdit)
                db.HDV_GBNNG.Add(X);
            else
            {
                HDV_GBNNG y = db.HDV_GBNNG.Find(X.GBNNG_SO);
                y.GBNNG_NGAY = X.GBNNG_NGAY;
                y.KUGN_SO = X.KUGN_SO;
                y.MSLNT = X.MSLNT;
                y.TYGIA = X.TYGIA;
                y.TIENGOC = X.TIENGOC;
                y.TIENGOCND = X.TIENGOCND;
                isEdit = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["ds_gbnng"] = db.HDV_GBNNG.ToList<HDV_GBNNG>();
            return View();
        }

        // xóa dữ liệu
        [HttpPost]
        public ActionResult Delete(string giaybao_xoa)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GBNNG x = db.HDV_GBNNG.Find(giaybao_xoa);
            db.HDV_GBNNG.Remove(x);
            db.SaveChanges();
            ViewData["ds_gbnng"] = db.HDV_GBNNG.ToList<HDV_GBNNG>();
            return View("Index");
        }

        // sửa dữ liệu
        [HttpPost]
        public ActionResult Edit(string giaybao_sua)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GBNNG x = db.HDV_GBNNG.Find(giaybao_sua);
            isEdit = true;
            ViewData["ds_gbnng"] = db.HDV_GBNNG.ToList<HDV_GBNNG>();
            return View("Index", x);
        }
    }
}