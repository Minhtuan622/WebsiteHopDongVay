using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHopDongVay.Models;

namespace WebsiteHopDongVay.Controllers
{
    public class HopDongVayController : Controller
    {
        private static bool isEdit = false;

        // GET: GiayBaoNhanLaiVay
        [HttpGet]
        public ActionResult Index()
        {
            List<HDV_VAY1> list = new dbQuanLyHopDongVayEntities().HDV_VAY1.ToList<HDV_VAY1>();
            ViewData["ds_hdv"] = list;
            return View();
        }

        // thêm dữ liệu
        [HttpPost]
        public ActionResult Index(HDV_VAY1 X)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            if (!isEdit)
                db.HDV_VAY1.Add(X);
            else
            {
                HDV_VAY1 y = db.HDV_VAY1.Find(X.HD_SO);
                y.HD_NGAY = X.HD_NGAY;
                y.MSNH = X.MSNH;
                y.MSLNT = X.MSLNT;
                y.TIENVAY = X.TIENVAY;
                y.TYGIA = X.TYGIA;
                y.RVTUNGAY = X.RVTUNGAY;
                y.RVDENNGAY = X.RVDENNGAY;
                y.SOTHANGVAY = X.SOTHANGVAY;
                y.KYHANTRANO = X.KYHANTRANO;
                y.HANTDLS = X.HANTDLS;
                y.TL_LS = X.TL_LS;
                y.TL_LSQH = X.TL_LSQH;
                y.LSTHEO = X.LSTHEO;
                y.TTGTHEO = X.TTGTHEO;
                y.TC_TSCD = X.TC_TSCD;
                y.TC_STK = X.TC_STK;
                y.TC_KHAC = X.TC_KHAC;
                y.TC_HD_SO = X.TC_HD_SO;
                y.TC_HD_NGAY = X.TC_HD_NGAY;
                y.STK_SO = X.STK_SO;
                y.STK_NGAY = X.STK_NGAY;
                y.STK_TRIGIA = X.STK_TRIGIA;
                y.STK_LS = X.STK_LS;
                y.STK_NDH = X.STK_NDH;
                y.STK_MSNH = X.STK_MSNH;
                y.STK_NSH = X.STK_NSH;
                isEdit = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["ds_hdv"] = db.HDV_VAY1.ToList<HDV_VAY1>();
            return View();
        }

        // xóa dữ liệu
        [HttpPost]
        public ActionResult Delete(string giaybao_xoa)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_VAY1 x = db.HDV_VAY1.Find(giaybao_xoa);
            db.HDV_VAY1.Remove(x);
            db.SaveChanges();
            ViewData["ds_hdv"] = db.HDV_VAY1.ToList<HDV_VAY1>();
            return View("Index");
        }

        // sửa dữ liệu
        [HttpPost]
        public ActionResult Edit(string giaybao_sua)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_VAY1 x = db.HDV_VAY1.Find(giaybao_sua);
            isEdit = true;
            ViewData["ds_hdv"] = db.HDV_VAY1.ToList<HDV_VAY1>();
            return View("Index", x);
        }
    }
}